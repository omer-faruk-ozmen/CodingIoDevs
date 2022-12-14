using CodingIoDevs.Application.Features.UserLinks.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.UserLinks.Commands.CreateUserLink;

public class CreateUserLinkCommand : IRequest<CreatedUserLinkDto>
{
    public string? GithubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
}