using Booking.Application.Dtos.User;
using Booking.Core.Models;

namespace Booking.Application.Interfaces.UserInterfaces;

public interface IUserService
{
    Task<Result<UserDto>> GetUserByIdAsync(int userId);
    Task<Result<UserDto>> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
}