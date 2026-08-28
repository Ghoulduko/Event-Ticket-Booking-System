using Booking.Core.Entities;

namespace Booking.Core.Interfaces;

public interface IEventRepository
{
    Task Create(Event request);
    Task<Event?> GetEventById(int eventId);
    Task<Event?> GetEventByName(string eventName);
    Task<bool> EventExists(string name);
    Task<IEnumerable<Event>> GetAllEvents();
    Task SaveChanges();
}