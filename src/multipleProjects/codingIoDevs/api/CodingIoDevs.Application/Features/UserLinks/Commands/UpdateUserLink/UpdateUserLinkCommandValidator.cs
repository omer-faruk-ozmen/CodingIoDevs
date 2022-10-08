using FluentValidation;

namespace CodingIoDevs.Application.Features.UserLinks.Commands.UpdateUserLink;

public class UpdateUserLinkCommandValidator : AbstractValidator<UpdateUserLinkCommand>
{
    public UpdateUserLinkCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}