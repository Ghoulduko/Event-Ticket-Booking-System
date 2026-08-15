using System.ComponentModel.DataAnnotations.Schema;
using Booking.Core.Models;

namespace Booking.Core.Entities;

[Table("Reservations")]
public class Reservation : BaseModel
{
    public int TicketId { get; set; }
    public int EventId { get; set; }
    
    public Ticket? Ticket { get; set; }
    public Event? Event { get; set; }
}