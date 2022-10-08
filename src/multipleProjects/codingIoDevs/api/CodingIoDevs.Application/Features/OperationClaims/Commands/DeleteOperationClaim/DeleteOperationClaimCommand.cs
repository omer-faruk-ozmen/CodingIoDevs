using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand:IRequest<DeletedOperationClaimDto>
    {
        public Guid OperationClaimId { get; set; }
    }
}
