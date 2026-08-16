using Booking.Application.Dtos.User;

namespace Booking.Application.Interfaces.User;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int userId);
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
}