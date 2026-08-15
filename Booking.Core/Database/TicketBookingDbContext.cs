
using Booking.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Database;

public class TicketBookingDbContext : DbContext
{
    public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}