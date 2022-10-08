using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
}