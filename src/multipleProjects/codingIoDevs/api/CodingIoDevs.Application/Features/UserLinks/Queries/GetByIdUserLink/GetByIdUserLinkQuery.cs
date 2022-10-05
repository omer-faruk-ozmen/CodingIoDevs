using CodingIoDevs.Application.Features.UserLinks.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.UserLinks.Queries.GetByIdUserLink;

public class GetByIdUserLinkQuery : IRequest<GetByIdUserLinkDto>
{
    public Guid UserId { get; set; }
}