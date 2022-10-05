using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
{
    public string Name { get; set; }
}