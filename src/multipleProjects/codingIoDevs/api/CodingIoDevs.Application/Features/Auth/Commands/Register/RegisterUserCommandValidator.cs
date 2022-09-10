using CodingIoDevs.Application.Features.Auth.Commands.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingIoDevs.Application.Features.Auth.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.Email).NotEmpty().EmailAddress();

        RuleFor(u => u.Password).NotEmpty().MinimumLength(8);

        RuleFor(u => u.FirstName).NotEmpty().Length(2, 30);

        RuleFor(u => u.LastName).NotEmpty().Length(2, 30);
    }
}