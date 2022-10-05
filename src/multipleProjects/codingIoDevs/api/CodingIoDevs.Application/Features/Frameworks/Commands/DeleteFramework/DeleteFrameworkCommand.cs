using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.DeleteFramework;

public class DeleteFrameworkCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}