using Booking.Application.Dtos.Seat;
using Booking.Application.Interfaces.SeatInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Ticket_Booking_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatController : Controller
{
    private readonly ISeatService _seatService;

    public SeatController(ISeatService seatService)
    {
        _seatService = seatService;
    }

    [HttpPost("CreateSeat")]
    public async Task<IActionResult> CreateSeat([FromBody] CreateSeatDto createSeatDto)
    {
        return Ok(await _seatService.Create(createSeatDto));
    }

    [HttpGet("GetSeatById/{seatId}")]
    public async Task<IActionResult> GetSeatById(int seatId)
    {
        return Ok(await _seatService.GetById(seatId));
    }

    [HttpGet("GetSeatsByEventId/{eventId}")]
    public async Task<IActionResult> GetSeatsByEventId(int eventId)
    {
        return Ok(await _seatService.GetSeatsByEventId(eventId));
    }
}