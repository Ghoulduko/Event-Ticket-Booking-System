using Booking.Application.Dtos.Seat;
using Booking.Application.Interfaces.Seat;
using Booking.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.Seat;

public class SeatService : ISeatService
{
    private readonly ISeatRepository _seatRepository;
    private readonly ILogger<SeatService> _logger;
    
    public SeatService(ISeatRepository seatRepository, ILogger<SeatService> logger)
    {
        _seatRepository = seatRepository;
        _logger = logger;
    }
    
    public Task Create(SeatDto seat)
    {
        throw new NotImplementedException();
    }

    public Task<SeatDto?> GetById(int seatId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SeatDto>> GetSeatsByEventId(int eventId)
    {
        throw new NotImplementedException();
    }
}