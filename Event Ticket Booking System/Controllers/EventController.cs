using Booking.Application.Dtos.Event;
using Booking.Application.Interfaces.EventInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Ticket_Booking_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : Controller
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost("AddEvent")]
    public async Task<IActionResult> Create(AddEventDto request)
    {
        return Ok(await _eventService.Create(request));
    }

    [HttpGet("GetEventById/{eventId}")]
    public async Task<IActionResult> GetEventById(int eventId)
    {
        return Ok(await _eventService.GetEventById(eventId));
    }

    [HttpGet("GetEventByName/{eventName}")]
    public async Task<IActionResult> GetEventByName(string eventName)
    {
        return Ok(await _eventService.GetEventByName(eventName));
    }
    
    [HttpGet("GetAllEvents")]
    public async Task<IActionResult> GetAllEvents()
    {
        return Ok(await _eventService.GetAllEvents());
    }
}