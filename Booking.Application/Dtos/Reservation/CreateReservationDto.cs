using Booking.Core.Enums;

namespace Booking.Application.Dtos.Reservation;

public class CreateReservationDto
{
    public decimal Price { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public int SeatId { get; set; }
    public ReservationStatus Status { get; set; }
    public DateTime ReservationDate { get; set; }
}