using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodingIoDevs.Application.Features.UserLinks.Commands.UpdateUserLink;

public class UpdateUserLinkCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
}