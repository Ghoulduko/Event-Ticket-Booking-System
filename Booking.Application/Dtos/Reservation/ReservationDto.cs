using Booking.Application.Dtos.Event;
using Booking.Application.Dtos.Seat;
using Booking.Application.Dtos.User;
using Booking.Core.Enums;

namespace Booking.Application.Dtos.Reservation;

public class ReservationDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public ReservationStatus Status { get; set; }
    public DateTime ReservationDate { get; set; }
    
    public UserDto? User { get; set; }
    public EventDto? Event { get; set; }
    public List<SeatDto>? Seats { get; set; }
}