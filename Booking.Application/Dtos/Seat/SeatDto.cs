namespace Booking.Application.Dtos.Seat;

public class SeatDto
{
    public int Id { get; set; }
    public bool IsAvailable { get; set; }
    public int Row { get; set; }
    public int EventId { get; set; }
}