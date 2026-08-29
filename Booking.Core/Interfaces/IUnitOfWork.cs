namespace Booking.Core.Interfaces;

public interface IUnitOfWork
{
    ISeatRepository Seats { get; }
    IReservationRepository Reservations { get; }
    
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}