using Booking.Application.Dtos.Auth;
using FluentValidation;

namespace Booking.Application.Validators.User;

public class RegisterUserValidator : AbstractValidator<RegisterRequestDto>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Name)
            .Matches("^[a-zA-Z]+$")
            .Length(2, 12)
            .WithMessage("Name can only contain letters.");
        
        RuleFor(u => u.LastName)
            .Matches("^[a-zA-Z]+$")
            .Length(5, 18)
            .WithMessage("Last Name can only contain letters.");
        
        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is invalid. please try again!");

        RuleFor(u => u.Password)
            .NotEmpty()
            .Length(8, 24)
            .WithMessage("Password is invalid. try using a different one.");
    }
}