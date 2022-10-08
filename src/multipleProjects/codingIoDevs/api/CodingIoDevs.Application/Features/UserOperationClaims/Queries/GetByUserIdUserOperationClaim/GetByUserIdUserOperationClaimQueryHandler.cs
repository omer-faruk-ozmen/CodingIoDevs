using AutoMapper;
using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using CodingIoDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;

public class GetByUserIdUserOperationClaimQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimQuery, UserOperationClaimSingleModel>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;

    public GetByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
    }

    public async Task<UserOperationClaimSingleModel> Handle(GetByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
    {


        var result = await _userOperationClaimRepository.GetListAsync(
            u => u.User.Id == request.UserId,
            include: m => m.Include(u => u.OperationClaim)
                .Include(u => u.User),
            index:
            request.PageRequest.Page,
            size:
            request.PageRequest.PageSize);

        UserOperationClaimSingleModel response = _mapper.Map<UserOperationClaimSingleModel>(result);

        return response;
    }
}