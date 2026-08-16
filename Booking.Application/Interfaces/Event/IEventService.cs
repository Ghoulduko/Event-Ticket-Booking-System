using Booking.Application.Dtos.Event;

namespace Booking.Application.Interfaces.Event;

public interface IEventService
{
    Task Create(EventDto request);
    Task<EventDto?> GetEventById(int eventId);
    Task<EventDto?> GetEventByName(string eventName);
    Task<IEnumerable<EventDto>> GetAllEvents();
}