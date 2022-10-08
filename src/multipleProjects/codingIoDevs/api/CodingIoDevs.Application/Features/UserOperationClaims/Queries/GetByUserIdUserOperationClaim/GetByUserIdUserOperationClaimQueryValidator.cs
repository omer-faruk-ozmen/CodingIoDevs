using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQueryValidator : AbstractValidator<GetByUserIdUserOperationClaimQuery>
    {
        public GetByUserIdUserOperationClaimQueryValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
