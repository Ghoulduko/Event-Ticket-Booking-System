using Booking.Application.Dtos.User;
using Booking.Application.Interfaces.User;
using Booking.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    
    public Task<UserDto> GetUserByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }
}