using Booking.Application.Dtos.Seat;
using Booking.Core.Entities;
using Booking.Core.Models;

namespace Booking.Application.Interfaces.SeatInterfaces;

public interface ISeatService
{
    Task<Result<SeatDto>> Create(CreateSeatDto seat);
    Task<Result<SeatDto>> GetById(int seatId);
    Task<IEnumerable<SeatDto>> GetSeatsByEventId(int eventId);
}