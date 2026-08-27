using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Booking.Application.Dtos.Auth;
using Booking.Application.Interfaces.AuthInterfaces;
using Booking.Core.Interfaces;
using Booking.Core.Entities;
using Booking.Core.Models;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Booking.Application.Services.AuthS;

public class JwtAuthenticationService : IJwtAuthenticationService
{
    public JwtAuthenticationService(
        IUserRepository userRepository, 
        ILogger<JwtAuthenticationService> logger,
        IValidator<RegisterRequestDto> registerValidator,
        IValidator<LoginRequestDto> loginValidator,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _logger = logger;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
        _configuration = configuration;
    }

    private readonly IUserRepository _userRepository;
    private readonly ILogger<JwtAuthenticationService> _logger;
    private readonly IValidator<RegisterRequestDto> _registerValidator;
    private readonly IValidator<LoginRequestDto> _loginValidator;
    private readonly IConfiguration _configuration;
    
    public async Task<Result<LoginResponseDto>> Register(RegisterRequestDto request)
    {
        await _registerValidator.ValidateAndThrowAsync(request);
        var existingUser = await _userRepository.GetUserByEmail(request.Email);
        if (existingUser != null)
        {
            return new Result<LoginResponseDto>
            {
                Success = false,
                Message = "User with that email already exists. try logging in."
            };
        }

        var newUser = new Core.Entities.User
        {
            Name = request.Name.ToUpper(),
            LastName = request.LastName.ToUpper(),
            Email = request.Email.ToLower(),
            Password = BC.HashPassword(request.Password, 7),
        };
        
        await _userRepository.AddUserAsync(newUser);
        
        var userWithId = await _userRepository.GetUserByEmail(newUser.Email.Trim().ToLower());
        if (userWithId == null)
        {
            return new Result<LoginResponseDto>
            {
                Success = false,
                Message = "User was not registered."
            };
        }

        return new Result<LoginResponseDto>()
        {
            Success = true,
            Data = GenerateJwtToken(userWithId)
        };
    }

    public async Task<Result<LoginResponseDto>> Login(LoginRequestDto request)
    {
        await _loginValidator.ValidateAndThrowAsync(request);
        var existingUser = await _userRepository.GetUserByEmail(request.Email.Trim().ToLower());
        if (existingUser == null)
        {
            return new Result<LoginResponseDto>
            {
                Success = false,
                Message = "Account is not registered with the provided Email."
            };
        }

        if (!BC.Verify(request.Password, existingUser.Password))
        {
            return new Result<LoginResponseDto>
            {
                Success = false,
                Message = "Password is invalid."
            };
        }

        return new Result<LoginResponseDto>
        {
            Success = true,
            Data = GenerateJwtToken(existingUser)
        };
    }

    private LoginResponseDto GenerateJwtToken(Core.Entities.User user)
    {
        var issuer = _configuration["JwtConfig:Issuer"];
        var audience = _configuration["JwtConfig:Audience"];
        var key = Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]);
        var tokenValidityMins = int.Parse(_configuration["JwtConfig:JwtTokenValidityMins"]);
        var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityMins);

        var claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Name", user.Name),
            new Claim("Email", user.Email),
        };

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            issuer,
            audience,
            claims,
            expires: tokenExpiryTimeStamp,
            signingCredentials: credentials
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginResponseDto()
        {
            Name = user.Name,
            AccessToken = accessToken,
            Expiration = tokenExpiryTimeStamp,
        };
    }
}