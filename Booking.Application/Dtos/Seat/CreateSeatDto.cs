namespace Booking.Application.Dtos.Seat;

public class CreateSeatDto
{
    public bool IsAvailable { get; set; }
    public int Row { get; set; }
    public int EventId { get; set; }
}