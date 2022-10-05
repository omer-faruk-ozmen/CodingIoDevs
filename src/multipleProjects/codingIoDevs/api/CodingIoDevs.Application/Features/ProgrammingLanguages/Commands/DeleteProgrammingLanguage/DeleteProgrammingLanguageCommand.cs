using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}