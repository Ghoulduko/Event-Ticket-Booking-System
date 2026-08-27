using Booking.Application.Dtos.Event;

namespace Booking.Application.Dtos.Seat;

public class SeatDto
{
    public bool IsAvailable { get; set; }
    public int Row { get; set; }
    public int EventId { get; set; }
    
    public EventDto? Event { get; set; }
}