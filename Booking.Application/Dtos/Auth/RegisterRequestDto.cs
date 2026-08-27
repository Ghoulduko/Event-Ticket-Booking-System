namespace Booking.Application.Dtos.Auth;

public class RegisterRequestDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}