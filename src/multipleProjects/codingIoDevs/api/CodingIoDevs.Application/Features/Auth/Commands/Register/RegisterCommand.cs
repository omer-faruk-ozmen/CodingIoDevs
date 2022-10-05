using CodingIoDevs.Application.Features.Auth.Dtos;
using Core.Security.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string? IpAddress { get; set; }
}