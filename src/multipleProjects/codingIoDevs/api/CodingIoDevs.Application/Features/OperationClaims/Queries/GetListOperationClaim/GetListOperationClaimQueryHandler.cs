using AutoMapper;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using CodingIoDevs.Application.Features.OperationClaims.Models;
using CodingIoDevs.Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;

    public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
    }

    public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
    {
        IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        OperationClaimListModel response = _mapper.Map<OperationClaimListModel>(operationClaims);

        return response;
    }
}