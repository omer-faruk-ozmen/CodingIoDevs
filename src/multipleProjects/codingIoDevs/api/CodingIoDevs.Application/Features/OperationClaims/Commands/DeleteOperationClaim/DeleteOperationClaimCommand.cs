using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand:IRequest<DeletedOperationClaimDto>,ISecuredRequest
{
    public Guid OperationClaimId { get; set; }
    public string[] Roles => new string[]{"admin","operationClaim.delete"};
}