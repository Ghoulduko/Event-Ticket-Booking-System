using Booking.Application.Dtos.Event;
using Booking.Application.Interfaces.EventInterfaces;
using Booking.Application.Services.Seat;
using Booking.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.Event;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly ILogger<SeatService> _logger;
    
    public EventService(IEventRepository eventRepository, ILogger<SeatService> logger)
    {
        _eventRepository = eventRepository;
        _logger = logger;
    }
    
    public Task Create(EventDto request)
    {
        throw new NotImplementedException();
    }

    public Task<EventDto?> GetEventById(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<EventDto?> GetEventByName(string eventName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EventDto>> GetAllEvents()
    {
        throw new NotImplementedException();
    }
}