
using Booking.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Database;

public class TicketBookingDbContext : DbContext
{
    public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Seat>()
            .HasOne(s => s.Reservation)
            .WithMany(r => r.Seats)
            .HasForeignKey(s => s.ReservationId)
            .OnDelete(DeleteBehavior.SetNull); 
        
        modelBuilder.Entity<Seat>()
            .HasOne(s => s.Event)
            .WithMany(e => e.TotalSeats)
            .HasForeignKey(s => s.EventId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}