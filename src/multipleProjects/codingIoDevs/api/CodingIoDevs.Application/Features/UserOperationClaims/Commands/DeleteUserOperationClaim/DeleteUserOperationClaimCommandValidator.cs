using FluentValidation;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommandValidator : AbstractValidator<DeleteUserOperationClaimCommand>
{
    public DeleteUserOperationClaimCommandValidator()
    {
        RuleFor(p => p.UserOperationClaimId).NotEmpty();
    }
}