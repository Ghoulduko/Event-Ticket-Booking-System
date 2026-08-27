namespace Booking.Application.Dtos.Auth;

public class LoginResponseDto
{
    public string? Name { get; set; }
    public string? AccessToken { get; set; }
    public DateTime Expiration { get; set; }
}