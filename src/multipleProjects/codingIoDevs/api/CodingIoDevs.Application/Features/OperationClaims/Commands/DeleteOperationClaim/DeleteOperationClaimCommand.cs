using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand:IRequest<DeletedOperationClaimDto>
{
    public Guid OperationClaimId { get; set; }
}