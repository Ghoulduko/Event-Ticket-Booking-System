using AutoMapper;
using Booking.Application.Dtos.Reservation;
using Booking.Application.Interfaces.ReservationInterfaces;
using Booking.Core.Entities;
using Booking.Core.Enums;
using Booking.Core.Interfaces;
using Booking.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.ReservationS;

public class ReservationService : IReservationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<ReservationService> _logger;
    
    public ReservationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReservationService> logger)
    {
        _unitOfWork = unitOfWork;
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
        
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            List<Seat> seats = new List<Seat>();

            foreach (var seatId in request.SeatsList)
            {
                var seat = await _unitOfWork.Seats.GetById(seatId);
                if (seat == null || !seat.IsAvailable)
                {
                    await _unitOfWork.RollbackAsync();
                    return new Result<ReservationDto>
                    {
                        Success = false,
                        Message = "Seat unavailable"
                    };
                }
                seats.Add(seat);
                seat.IsAvailable = false;
            }

            await _unitOfWork.Seats.SaveChanges();

            var reservation = new Reservation
            {
                Price = request.SeatsList.Count * 50,
                UserId = userId,
                EventId = request.EventId,
                Seats = seats,
                Status = ReservationStatus.Confirmed,
                ReservationDate = DateTime.UtcNow
            };
        
            await _unitOfWork.Reservations.Create(reservation);
            await _unitOfWork.CommitAsync();

            return new Result<ReservationDto>
            {
                Success = true,
                Message = "Reservation created successfully",
                Data = _mapper.Map<ReservationDto>(reservation)
            };
        }
        catch (DbUpdateConcurrencyException)
        {
            await _unitOfWork.RollbackAsync();
            return new Result<ReservationDto>
            {
                Success = false,
                Message = "Someone booked a seat first"
            };
        }
    }

    public async Task<Result<ReservationDto>> GetReservationById(int reservationId)
    {
        var reservation = await _unitOfWork.Reservations.GetReservationById(reservationId);
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
        var reservation = await _unitOfWork.Reservations.GetReservationByUserEmail(email);
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
        var eventReservations = await _unitOfWork.Reservations.GetEventReservations(eventId);
        return _mapper.Map<List<ReservationDto>>(eventReservations);
    }
}