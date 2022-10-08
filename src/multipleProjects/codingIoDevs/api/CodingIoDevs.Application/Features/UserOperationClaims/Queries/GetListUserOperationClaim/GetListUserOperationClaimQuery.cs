using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;

public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>
{
    public PageRequest PageRequest { get; set; }
}