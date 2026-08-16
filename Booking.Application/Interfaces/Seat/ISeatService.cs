using Booking.Application.Dtos.Seat;

namespace Booking.Application.Interfaces.Seat;

public interface ISeatService
{
    Task Create(SeatDto seat);
    Task<SeatDto?> GetById(int seatId);
    Task<IEnumerable<SeatDto>> GetSeatsByEventId(int eventId);
}