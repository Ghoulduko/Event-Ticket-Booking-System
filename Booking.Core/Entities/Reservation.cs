using System.ComponentModel.DataAnnotations.Schema;
using Booking.Core.Enums;
using Booking.Core.Models;

namespace Booking.Core.Entities;

[Table("Reservations")]
public class Reservation : BaseModel
{
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public ReservationStatus Status { get; set; }
    public DateTime ReservationDate { get; set; }
    
    public User? User { get; set; }
    public Event? Event { get; set; }
    public List<Seat>? Seats { get; set; }
}