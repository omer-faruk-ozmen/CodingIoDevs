using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using Core.Application.Requests;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;

public class GetByUserIdUserOperationClaimQuery : IRequest<UserOperationClaimSingleModel>
{
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }
}