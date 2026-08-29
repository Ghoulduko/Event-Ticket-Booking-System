using Booking.Core.Database;
using Booking.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Booking.Core.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TicketBookingDbContext _context;
    private IDbContextTransaction? _transaction;
    
    public ISeatRepository Seats { get; }
    public IReservationRepository Reservations { get; }
    
    public UnitOfWork(TicketBookingDbContext context, ISeatRepository seats, IReservationRepository reservations)
    {
        _context = context;
        Seats = seats;
        Reservations = reservations;
    }
    
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
        await _transaction!.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction?.RollbackAsync()!;
    }
}