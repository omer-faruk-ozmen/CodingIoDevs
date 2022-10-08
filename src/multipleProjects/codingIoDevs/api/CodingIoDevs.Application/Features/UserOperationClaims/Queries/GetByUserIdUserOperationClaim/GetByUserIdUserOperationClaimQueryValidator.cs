using FluentValidation;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;

public class GetByUserIdUserOperationClaimQueryValidator : AbstractValidator<GetByUserIdUserOperationClaimQuery>
{
    public GetByUserIdUserOperationClaimQueryValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
    }
}