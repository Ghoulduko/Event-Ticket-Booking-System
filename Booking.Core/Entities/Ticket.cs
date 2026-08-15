using System.ComponentModel.DataAnnotations.Schema;
using Booking.Core.Models;

namespace Booking.Core.Entities;

[Table("Tickets")]
public class Ticket : BaseModel
{
    public decimal Price { get; set; }
    public int EventId { get; set; }
    public int SeatId { get; set; }
    
    public Event Event { get; set; }
    public Seat Seat { get; set; }
}