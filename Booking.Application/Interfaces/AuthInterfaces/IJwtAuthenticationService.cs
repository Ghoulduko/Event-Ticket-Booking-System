using Booking.Application.Dtos.Auth;
using Booking.Core.Entities;
using Booking.Core.Models;

namespace Booking.Application.Interfaces.AuthInterfaces;

public interface IJwtAuthenticationService
{
    Task<Result<LoginResponseDto>> Register(RegisterRequestDto request);
    Task<Result<LoginResponseDto>> Login(LoginRequestDto request);
}