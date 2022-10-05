using FluentValidation;

namespace CodingIoDevs.Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(u => u.UserForLoginDto.Email).NotEmpty().EmailAddress();
        RuleFor(u => u.UserForLoginDto.Password).NotEmpty().MinimumLength(8);
    }
}