using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        UserOperationClaim userOperationClaim = new UserOperationClaim()
        {
            OperationClaimId = request.OperationClaimId,
            UserId = request.UserId,
        };
        await _userOperationClaimRepository.AddAsync(userOperationClaim);


        return new();
    }
}