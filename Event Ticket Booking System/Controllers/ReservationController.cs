using Booking.Application.Dtos.Reservation;
using Booking.Application.Interfaces.ReservationInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Ticket_Booking_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : Controller
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost("CreateReservation")]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto request)
    {
        var userId = User.FindFirst("Id")?.Value;
        if (userId == null)
            return BadRequest("You need to login");
        return Ok(await _reservationService.Create(request, int.Parse(userId)));
    }

    [HttpGet("GetReservationById/{reservationId}")]
    public async Task<IActionResult> GetReservationById(int reservationId)
    {
        return Ok(await _reservationService.GetReservationById(reservationId));
    }

    [HttpGet("GetReservationByUserEmail/{userEmail}")]
    public async Task<IActionResult> GetReservationByUserEmail(string userEmail)
    {
        return Ok(await _reservationService.GetReservationByUserEmail(userEmail));
    }

    [HttpGet("GetEventReservations/{eventId}")]
    public async Task<IActionResult> GetEventReservations(int eventId)
    {
        return Ok(await _reservationService.GetEventReservations(eventId));
    }
}