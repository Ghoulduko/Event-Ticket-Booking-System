using Booking.Core.Database;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Repositories;

public class EventRepository : IEventRepository
{
    private readonly TicketBookingDbContext _context;
    private readonly DbSet<Event> _events;
    
    public EventRepository(TicketBookingDbContext context)
    {
        _context = context;
        _events = _context.Events;
    }

    private IQueryable<Event> BaseQuery()
    {
        return _events
            .Include(e => e.TotalSeats);
    }

    public async Task Create(Event request)
    {
        await _events.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task<Event?> GetEventById(int eventId)
    {
        return await BaseQuery().FirstOrDefaultAsync(e => e.Id == eventId);
    }
    public async Task<Event?> GetEventByName(string eventName)
    {
        return await BaseQuery().FirstOrDefaultAsync(e => e.Name == eventName);
    }

    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        return await BaseQuery().ToListAsync();
    }

    
}