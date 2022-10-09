using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
{
    public string RoleName { get; set; }

    public string[] Roles => new string[]
    {
        "operationClaim.create","admin"
    };
}