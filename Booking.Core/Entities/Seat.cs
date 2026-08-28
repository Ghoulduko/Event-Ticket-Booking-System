using System.ComponentModel.DataAnnotations.Schema;
using Booking.Core.Models;

namespace Booking.Core.Entities;

[Table("Seats")]
public class Seat : BaseModel
{
    public bool IsAvailable { get; set; }
    public int Row { get; set; }
    public int EventId { get; set; }
    public int? ReservationId { get; set; }
    
    public Event? Event { get; set; }
    public Reservation? Reservation { get; set; }
}