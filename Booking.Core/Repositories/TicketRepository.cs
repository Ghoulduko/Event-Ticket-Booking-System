using Booking.Core.Database;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly TicketBookingDbContext _context;
    private readonly DbSet<Ticket> _tickets;

    public TicketRepository(TicketBookingDbContext context)
    {
        _context = context;
        _tickets = _context.Tickets;
    }
        
    public async Task CreateTicket(Ticket ticket)
    {
        await _tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
    }

    private IQueryable<Ticket> BaseQuery()
    {
        return _tickets
            .Include(t => t.User)
            .Include(t => t.Event)
            .Include(t => t.Seat);
    }

    public async Task<Ticket?> GetTicketById(int ticketId)
    {
        return await BaseQuery().FirstOrDefaultAsync(t => t.Id == ticketId);
    }

    public async Task<IEnumerable<Ticket>> GetAllTickets()
    {
        return await BaseQuery().ToListAsync(); 
    }
}