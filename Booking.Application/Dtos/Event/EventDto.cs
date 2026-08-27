using Booking.Application.Dtos.Seat;

namespace Booking.Application.Dtos.Event;

public class EventDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime EventDate { get; set; }
    public List<SeatDto> TotalSeats { get; set; }
    public DateTime CreatedAt { get; set; }
}