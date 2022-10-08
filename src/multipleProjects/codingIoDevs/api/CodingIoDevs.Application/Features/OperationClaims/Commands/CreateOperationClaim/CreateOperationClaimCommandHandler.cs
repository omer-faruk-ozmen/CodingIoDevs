using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using CodingIoDevs.Application.Features.OperationClaims.Rules;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _operationClaimBusinessRules.OperationClaimShouldNotDuplicatedWhenInserted(request.RoleName);

        OperationClaim operationClaim = new()
        {
            Name = request.RoleName
        };

        _operationClaimBusinessRules.OperationClaimMustNotBeEmpty(operationClaim);

        await _operationClaimRepository.AddAsync(operationClaim);

        return new();
    }
}