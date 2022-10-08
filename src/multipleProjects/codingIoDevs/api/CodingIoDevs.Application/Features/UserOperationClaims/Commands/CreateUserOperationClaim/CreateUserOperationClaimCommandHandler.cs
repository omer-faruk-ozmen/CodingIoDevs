using AutoMapper;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using CodingIoDevs.Application.Features.UserOperationClaims.Rules;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
{
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;

    public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserOperationClaimBusinessRules userOperationClaimBusinessRules, IMapper mapper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _userOperationClaimBusinessRules.OperationClaimShouldExist(request.OperationClaimId);
        await _userOperationClaimBusinessRules.UserShouldExist(request.UserId);



        UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);

        await _userOperationClaimBusinessRules.RolesCanBeAddedOncePerUser(userOperationClaim);

        await _userOperationClaimRepository.AddAsync(userOperationClaim);


        return new();
    }
}