using FluentValidation;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
{

    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(l => l.Name).NotEmpty();
    }
}