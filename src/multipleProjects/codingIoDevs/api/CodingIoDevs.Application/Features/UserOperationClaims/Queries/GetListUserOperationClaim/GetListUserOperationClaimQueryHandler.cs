using AutoMapper;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using CodingIoDevs.Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;

public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;

    public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
    }

    public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
    {
        IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
            include: o => o.Include(o => o.OperationClaim).Include(u => u.User), index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);


        UserOperationClaimListModel response =
            _mapper.Map<UserOperationClaimListModel>(userOperationClaims);

        return response;

    }


}