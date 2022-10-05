using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}