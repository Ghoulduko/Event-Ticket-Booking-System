using Booking.Application.Dtos.Auth;
using FluentValidation;

namespace Booking.Application.Validators.User;

public class LoginUserValidator : AbstractValidator<LoginRequestDto>
{
    public LoginUserValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Invalid email address.");
        
        RuleFor(u => u.Password)
            .NotEmpty()
            .Length(8, 24)
            .WithMessage("Password is invalid. Try using a valid password.");
    }
}