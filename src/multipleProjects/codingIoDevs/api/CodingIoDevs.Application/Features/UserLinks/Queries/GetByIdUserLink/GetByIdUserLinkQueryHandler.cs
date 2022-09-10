using AutoMapper;
using CodingIoDevs.Application.Features.UserLinks.Dtos;
using CodingIoDevs.Application.Features.UserLinks.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.UserLinks.Queries.GetByIdUserLink;

public class GetByIdUserLinkQueryHandler : IRequestHandler<GetByIdUserLinkQuery, GetByIdUserLinkDto>
{
    private readonly IUserLinkRepository _userLinkRepository;
    private readonly IMapper _mapper;
    private readonly UserLinkBusinessRules _userLinkBusinessRules;

    public GetByIdUserLinkQueryHandler(IUserLinkRepository userLinkRepository, IMapper mapper, UserLinkBusinessRules userLinkBusinessRules)
    {
        _userLinkRepository = userLinkRepository;
        _mapper = mapper;
        _userLinkBusinessRules = userLinkBusinessRules;
    }

    public async Task<GetByIdUserLinkDto> Handle(GetByIdUserLinkQuery request, CancellationToken cancellationToken)
    {
        UserLink? userLink = await _userLinkRepository.GetAsync(p => p.UserId == request.UserId);

        _userLinkBusinessRules.UserLinkShouldExistWhenRequested(userLink);

        GetByIdUserLinkDto response = _mapper.Map<GetByIdUserLinkDto>(userLink);
        

        return response;
    }
}