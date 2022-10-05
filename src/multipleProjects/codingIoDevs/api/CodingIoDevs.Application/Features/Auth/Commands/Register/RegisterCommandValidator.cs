using FluentValidation;

namespace CodingIoDevs.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(u => u.UserForRegisterDto.Email).NotEmpty().EmailAddress();

        RuleFor(u => u.UserForRegisterDto.Password).NotEmpty().MinimumLength(8);

        RuleFor(u => u.UserForRegisterDto.FirstName).NotEmpty().Length(2, 30);

        RuleFor(u => u.UserForRegisterDto.LastName).NotEmpty().Length(2, 30);
    }
}