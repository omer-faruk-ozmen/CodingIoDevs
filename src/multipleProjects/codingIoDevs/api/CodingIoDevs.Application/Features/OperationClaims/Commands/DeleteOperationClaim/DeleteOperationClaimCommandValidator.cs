using FluentValidation;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
{
    public DeleteOperationClaimCommandValidator()
    {
        RuleFor(p => p.OperationClaimId).NotEmpty();
    }
}