using Booking.Application.Dtos.User;
using Booking.Application.Interfaces.UserInterfaces;
using Booking.Core.Interfaces;
using Booking.Core.Models;
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
    
    public async Task<Result<UserDto>> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserById(userId);
        if (user == null)
        {
            return new Result<UserDto>
            {
                Success = false,
                Message = "User not found"
            };
        }

        return new Result<UserDto>
        {
            Success = true,
            Data = new UserDto
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
            }
        };
    }

    public async Task<Result<UserDto>> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user == null)
        {
            return new Result<UserDto>
            {
                Success = false,
                Message = "User not found"
            };
        }

        return new Result<UserDto>
        {
            Success = true,
            Data = new UserDto
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
            }
        };
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var allUsers = await _userRepository.GetAllUsers();
        var userDtos = allUsers.Select(u => new UserDto
        {
            Name = u.Name,
            LastName = u.LastName,
            Email = u.Email,
        });
        
        return userDtos;
    }
}