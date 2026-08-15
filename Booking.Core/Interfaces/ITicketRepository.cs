using Booking.Core.Entities;

namespace Booking.Core.Interfaces;

public interface ITicketRepository
{
    Task CreateTicket(Ticket ticket);
    Task<Ticket?> GetTicketById(int ticketId);
    Task<IEnumerable<Ticket>> GetAllTickets();
}