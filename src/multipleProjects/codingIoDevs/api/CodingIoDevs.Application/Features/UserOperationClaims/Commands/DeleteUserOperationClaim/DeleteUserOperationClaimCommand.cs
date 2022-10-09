using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>,ISecuredRequest
{
    public Guid UserOperationClaimId { get; set; }
    public string[] Roles => new string[] { "admin", "userOperationClaim.delete" };
}