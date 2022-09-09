using FluentValidation;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.CreateFramework;

public class CreateFrameworkCommandValidator : AbstractValidator<CreateFrameworkCommand>
{
    public CreateFrameworkCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(1);

        RuleFor(p => p.ProgrammingLanguageId).NotEmpty();
    }
}