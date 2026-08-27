using Booking.Core.Entities;

namespace Booking.Core.Interfaces;

public interface ISeatRepository
{
    Task Create(Seat seat);
    Task<Seat?> GetById(int seatId);
    Task<IEnumerable<Seat>> GetSeatsByEventId(int eventId);
}