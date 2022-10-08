using FluentValidation;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
{
    public CreateUserOperationClaimCommandValidator()
    {
        RuleFor(p => p.OperationClaimId).NotEmpty();
        RuleFor(p => p.UserId).NotEmpty();
    }
}