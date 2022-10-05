using FluentValidation;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguagesCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
{
    public DeleteProgrammingLanguagesCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}