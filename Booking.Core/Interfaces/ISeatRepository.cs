using Booking.Core.Entities;
using Booking.Core.Repositories;

namespace Booking.Core.Interfaces;

public interface ISeatRepository
{
    Task Create(Seat seat);
    Task<Seat?> GetById(int seatId);
    Task<IEnumerable<Seat>> GetSeatsByEventId(int eventId);
    Task SaveChanges();
}