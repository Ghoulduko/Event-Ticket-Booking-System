using Booking.Core.Database;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Repositories;

public class SeatRepository : BaseRepository, ISeatRepository
{
    private readonly TicketBookingDbContext _context;
    private readonly DbSet<Seat> _seats;
    
    public SeatRepository(TicketBookingDbContext context) : base(context)
    {
        _context = context;
        _seats = _context.Seats;
    }

    public async Task Create(Seat seat)
    {
        await _seats.AddAsync(seat);
        await _context.SaveChangesAsync();
    }

    public async Task<Seat?> GetById(int seatId)
    {
        return await _seats.FindAsync(seatId);
    }

    public async Task<IEnumerable<Seat>> GetSeatsByEventId(int eventId)
    {
        return await _seats.Where(s => s.EventId == eventId).ToListAsync();
    }
}