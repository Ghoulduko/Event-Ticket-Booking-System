using Booking.Core.Enums;

namespace Booking.Application.Dtos.Reservation;

public class CreateReservationDto
{
    public int EventId { get; set; }
    public List<int> SeatsList { get; set; }
}