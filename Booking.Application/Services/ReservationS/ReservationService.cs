using AutoMapper;
using Booking.Application.Dtos.Reservation;
using Booking.Application.Interfaces.ReservationInterfaces;
using Booking.Core.Entities;
using Booking.Core.Enums;
using Booking.Core.Interfaces;
using Booking.Core.Models;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.ReservationS;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ReservationService> _logger;
    
    public ReservationService(IReservationRepository reservationRepository, ISeatRepository seatRepository, IMapper mapper, ILogger<ReservationService> logger)
    {
        _reservationRepository = reservationRepository;
        _seatRepository = seatRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Result<ReservationDto>> Create(CreateReservationDto request, int userId)
    {
        if (userId <= 0)
        {
            return new Result<ReservationDto>
            {
                Success = false,
                Message = "Invalid User ID"
            };
        }
        
        if (request.EventId <= 0)
        {
            return new Result<ReservationDto>
            {
                Success = false,
                Message = "Invalid Event ID"
            };
        }
        
        if (request.SeatsList.Count <= 0)
        {
            return new Result<ReservationDto>
            {
                Success = false,
                Message = "Invalid Seats"
            };
        }

        List<Seat> seats = new List<Seat>();

        foreach (var seatId in request.SeatsList)
        {
            var seat = await _seatRepository.GetById(seatId);
            if (seat == null)
            {
                return new Result<ReservationDto>
                {
                    Success = false,
                    Message = "Invalid Seat"
                };
            } else if (!seat.IsAvailable)
            {
                return new Result<ReservationDto>
                {
                    Success = false,
                    Message = "Seat is already reserved by someone else."
                };
            }
            
            seats.Add(seat);
            seat.IsAvailable = false;
            await _seatRepository.SaveChanges();
        }

        var reservation = new Reservation
        {
            Price = request.SeatsList.Count * 50,
            UserId = userId,
            EventId = request.EventId,
            Seats = seats,
            Status = ReservationStatus.Confirmed,
            ReservationDate = DateTime.UtcNow
        };
        
        await _reservationRepository.Create(reservation);

        return new Result<ReservationDto>
        {
            Success = true,
            Message = "Reservation created successfully"
        };
    }

    public async Task<Result<ReservationDto>> GetReservationById(int reservationId)
    {
        var reservation = await _reservationRepository.GetReservationById(reservationId);
        if (reservation == null)
        {
            return new Result<ReservationDto>
            {
                Success = false,
                Message = "Reservation not found"
            };
        }

        return new Result<ReservationDto>
        {
            Success = true,
            Message = "Reservation successfully retrieved",
            Data = _mapper.Map<ReservationDto>(reservation)
        };
    }

    public async Task<Result<ReservationDto>> GetReservationByUserEmail(string email)
    {
        var reservation = await _reservationRepository.GetReservationByUserEmail(email);
        if (reservation == null)
        {
            return new Result<ReservationDto>
            {
                Success = false,
                Message = "Reservation not found"
            };
        }

        return new Result<ReservationDto>
        {
            Success = true,
            Message = "Reservation successfully retrieved",
            Data = _mapper.Map<ReservationDto>(reservation)
        };
    }
    
    public async Task<IEnumerable<ReservationDto>> GetEventReservations(int eventId)
    {
        var eventReservations = await _reservationRepository.GetEventReservations(eventId);
        return _mapper.Map<List<ReservationDto>>(eventReservations);
    }
}