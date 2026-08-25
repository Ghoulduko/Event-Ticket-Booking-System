using Booking.Core.Entities;

namespace Booking.Core.Interfaces;

public interface IReservationRepository
{
    Task Create(Reservation request);
    Task<Reservation?> GetReservationById(int reservationId);
    Task<Reservation?> GetReservationByUserEmail(string email);
    Task<IEnumerable<Reservation>> GetEventReservations(int eventId);
}