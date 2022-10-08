using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.OperationClaims.Models;
using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
