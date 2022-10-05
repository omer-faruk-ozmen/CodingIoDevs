using CodingIoDevs.Application.Features.Auth.Dtos;
using Core.Security.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoginDto>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string? IpAddress { get; set; }
}