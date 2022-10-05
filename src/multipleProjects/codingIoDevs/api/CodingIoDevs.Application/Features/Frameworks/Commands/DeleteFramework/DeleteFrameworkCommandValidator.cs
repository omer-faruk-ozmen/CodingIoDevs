using FluentValidation;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.DeleteFramework;

public class DeleteFrameworkCommandValidator : AbstractValidator<DeleteFrameworkCommand>
{
    public DeleteFrameworkCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}