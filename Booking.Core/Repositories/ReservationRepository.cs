using Booking.Core.Database;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Repositories;

public class ReservationRepository : BaseRepository, IReservationRepository
{
    private readonly TicketBookingDbContext _context;
    private readonly DbSet<Reservation> _reservations;

    public ReservationRepository(TicketBookingDbContext context) : base(context)
    {
        _context = context;
        _reservations = _context.Reservations;
    }

    private IQueryable<Reservation> BaseQuery()
    {
        return _reservations
            .Include(r => r.User)
            .Include(r => r.Event)
            .Include(r => r.Seats);
    }
    
    public async Task Create(Reservation request)
    {
        await _reservations.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task<Reservation?> GetReservationById(int reservationId)
    {
        return await BaseQuery().SingleOrDefaultAsync(r => r.Id == reservationId);
    }

    public async Task<Reservation?> GetReservationByUserEmail(string email)
    {
        return await BaseQuery().SingleOrDefaultAsync(r => r.User.Email.Equals(email));
    }

    public async Task<IEnumerable<Reservation>> GetEventReservations(int eventId)
    {
        return await BaseQuery().Where(r => r.EventId == eventId).ToListAsync();
    }
}