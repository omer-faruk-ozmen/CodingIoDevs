using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.UpdateFramework;

public class UpdateFrameworkCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
}