using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using CodingIoDevs.Application.Services.Repositories;
using FluentValidation;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _operationClaimRepository.DeleteAsync(request.OperationClaimId);

        return new();
    }
}