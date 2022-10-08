using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
    {
        public Guid UserOperationClaimId { get; set; }
    }
}
