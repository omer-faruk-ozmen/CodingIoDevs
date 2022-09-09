using AutoMapper;
using CodingIoDevs.Application.Features.UserLinks.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CodingIoDevs.Application.Features.UserLinks.Commands.UpdateUserLink;

public class UpdateUserLinkCommandHandler : IRequestHandler<UpdateUserLinkCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IUserLinkRepository _userLinkRepository;
    private readonly UserLinkBusinessRules _userLinkBusinessRules;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UpdateUserLinkCommandHandler(IMapper mapper, IUserLinkRepository userLinkRepository, UserLinkBusinessRules userLinkBusinessRules, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _userLinkRepository = userLinkRepository;
        _userLinkBusinessRules = userLinkBusinessRules;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(UpdateUserLinkCommand request, CancellationToken cancellationToken)
    {
        var claims = _httpContextAccessor?.HttpContext.User.Claims;
        var claimsList = claims as Claim[] ?? claims.ToArray();
        var userId = claimsList[0].Value;

        UserLink? dbUserLink = await _userLinkRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, dbUserLink);

        dbUserLink.UserId = Guid.Parse(userId);

        await _userLinkRepository.UpdateAsync(dbUserLink);

        return dbUserLink.Id;

    }
}