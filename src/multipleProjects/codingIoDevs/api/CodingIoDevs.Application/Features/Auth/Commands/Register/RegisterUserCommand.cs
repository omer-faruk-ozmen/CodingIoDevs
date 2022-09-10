using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.Auth.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.Auth.Commands.Register;

public class RegisterUserCommand : IRequest<RegisterUserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}