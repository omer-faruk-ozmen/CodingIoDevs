using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
{
    public string RoleName { get; set; }
}