using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
{
    public Guid UserOperationClaimId { get; set; }
}