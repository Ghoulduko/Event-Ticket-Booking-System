using Booking.Application.Interfaces.UserInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Event_Ticket_Booking_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUserById/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(await _userService.GetUserByIdAsync(id));
    }
    
    [HttpGet("GetUserByEmail/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        return Ok(await _userService.GetUserByEmailAsync(email));
    }
    
    [HttpGet("GetUserProfile")]
    public async Task<IActionResult> GetUserById()
    {
        var userId = User.FindFirst("Id").Value;
        return Ok(await _userService.GetUserByIdAsync(int.Parse(userId)));
    }
    
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }
}