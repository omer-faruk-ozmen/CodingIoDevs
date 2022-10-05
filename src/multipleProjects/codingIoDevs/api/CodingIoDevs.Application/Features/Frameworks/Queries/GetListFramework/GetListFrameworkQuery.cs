using CodingIoDevs.Application.Features.Frameworks.Models;
using Core.Application.Requests;
using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Queries.GetListFramework;

public class GetListFrameworkQuery : IRequest<FrameworkListModel>
{
    public PageRequest PageRequest { get; set; }
}