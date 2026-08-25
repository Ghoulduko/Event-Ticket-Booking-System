using Booking.Application.Dtos.Event;
using Booking.Core.Models;

namespace Booking.Application.Interfaces.EventInterfaces;

public interface IEventService
{
    Task<Result<EventDto>> Create(AddEventDto request);
    Task<Result<EventDto>> GetEventById(int eventId);
    Task<Result<EventDto>> GetEventByName(string eventName);
    Task<IEnumerable<EventDto>> GetAllEvents();
}