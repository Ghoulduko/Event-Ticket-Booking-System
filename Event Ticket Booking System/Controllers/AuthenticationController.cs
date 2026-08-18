using Booking.Application.Dtos.Auth;
using Booking.Application.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Ticket_Booking_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly IJwtAuthenticationService _jwtAuthenticationService;

    public AuthenticationController(IJwtAuthenticationService jwtAuthenticationService)
    {
        _jwtAuthenticationService = jwtAuthenticationService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        return Ok(await _jwtAuthenticationService.Register(request));
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        return Ok(await _jwtAuthenticationService.Login(request));
    }
}