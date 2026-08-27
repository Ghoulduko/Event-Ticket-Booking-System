using AutoMapper;
using Booking.Application.Dtos.Reservation;
using Booking.Application.Interfaces.ReservationInterfaces;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Booking.Core.Models;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.ReservationS;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ReservationService> _logger;
    
    public ReservationService(IReservationRepository reservationRepository, IMapper mapper, ILogger<ReservationService> logger)
    {
        _reservationRepository = reservationRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Result<ReservationDto>> Create(CreateReservationDto request)
    {
        if (request.UserId <= 0)
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
        
        if (request.SeatId <= 0)
        {
            return new Result<ReservationDto>
            {
                Success = false,
                Message = "Invalid Seat ID"
            };
        }

        var reservation = new Reservation
        {
            Price = request.Price,
            UserId = request.UserId,
            EventId = request.EventId,
            SeatId = request.SeatId,
            ReservationDate = request.ReservationDate,
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