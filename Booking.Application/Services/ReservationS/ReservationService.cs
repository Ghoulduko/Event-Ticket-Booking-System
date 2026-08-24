using Booking.Application.Dtos.Reservation;
using Booking.Application.Interfaces.ReservationInterfaces;
using Booking.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.ReservationS;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ILogger<ReservationService> _logger;
    
    public ReservationService(IReservationRepository reservationRepository, ILogger<ReservationService> logger)
    {
        _reservationRepository = reservationRepository;
        _logger = logger;
    }
    
    public Task Create(ReservationDto request)
    {
        throw new NotImplementedException();
    }

    public Task<ReservationDto?> GetReservationById(int reservationId)
    {
        throw new NotImplementedException();
    }

    public Task<ReservationDto?> GetReservationByUserEmail(int email)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ReservationDto>> GetEventReservations(int eventId)
    {
        throw new NotImplementedException();
    }
}