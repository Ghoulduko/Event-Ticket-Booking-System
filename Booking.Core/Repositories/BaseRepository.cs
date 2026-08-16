using Booking.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Repositories;

public abstract class BaseRepository
{
    private readonly TicketBookingDbContext _context;

    public BaseRepository(TicketBookingDbContext context)
    {
        _context = context;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}