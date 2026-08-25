namespace Booking.Application.Dtos.Event;

public class AddEventDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime EventDate { get; set; }
}