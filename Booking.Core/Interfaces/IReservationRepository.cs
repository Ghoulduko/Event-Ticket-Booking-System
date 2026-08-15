using Booking.Core.Entities;

namespace Booking.Core.Interfaces;

public interface IReservationRepository
{
    Task Create(Reservation request);
    Task<Reservation?> GetReservationById(int reservationId);
    Task<Reservation?> GetReservationByTicketId(int ticketId);
    Task<IEnumerable<Reservation>> GetEventReservations(int eventId);
}