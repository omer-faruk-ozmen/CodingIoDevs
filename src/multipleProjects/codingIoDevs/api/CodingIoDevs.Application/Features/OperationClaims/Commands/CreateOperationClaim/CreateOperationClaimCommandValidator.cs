using FluentValidation;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(p => p.RoleName).NotEmpty().MinimumLength(2);
    }
}