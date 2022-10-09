using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>,ISecuredRequest
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public string[] Roles => new string[] { "admin", "userOperationClaim.create" };
}