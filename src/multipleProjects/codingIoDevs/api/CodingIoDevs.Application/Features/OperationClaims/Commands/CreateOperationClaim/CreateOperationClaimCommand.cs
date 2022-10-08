using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
    {
        public string RoleName { get; set; }
    }
}
