using Booking.Application.Dtos.Reservation;

namespace Booking.Application.Interfaces.Reservation;

public interface IReservationService
{
    Task Create(ReservationDto request);
    Task<ReservationDto?> GetReservationById(int reservationId);
    Task<ReservationDto?> GetReservationByUserEmail(int email);
    Task<IEnumerable<ReservationDto>> GetEventReservations(int eventId);
}