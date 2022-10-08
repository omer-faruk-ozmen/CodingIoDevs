using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQuery : IRequest<UserOperationClaimSingleModel>
    {
        public Guid UserId { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}
