using System.Security.Claims;
using AutoMapper;
using CodingIoDevs.Application.Features.UserLinks.Dtos;
using CodingIoDevs.Application.Features.UserLinks.Rules;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using Core.Security.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CodingIoDevs.Application.Features.UserLinks.Commands.CreateUserLink;

public class CreateUserLinkCommandHandler : IRequestHandler<CreateUserLinkCommand, CreatedUserLinkDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserLinkRepository _userLinkRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly UserLinkBusinessRules _userLinkBusinessRules;



    public CreateUserLinkCommandHandler(IUserLinkRepository userLinkRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserLinkBusinessRules userLinkBusinessRules, IUserRepository userRepository)
    {
        _userLinkRepository = userLinkRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _userLinkBusinessRules = userLinkBusinessRules;
        _userRepository = userRepository;
    }

    public async Task<CreatedUserLinkDto> Handle(CreateUserLinkCommand request, CancellationToken cancellationToken)
    {
        var claims = _httpContextAccessor?.HttpContext.User.Claims;
        var claimsList = claims as Claim[] ?? claims.ToArray();
        var userId = claimsList[0].Value;


        UserLink mappedUserLink = _mapper.Map<UserLink>(request);

        mappedUserLink.UserId = Guid.Parse(userId);

        UserLink createdUserLink = await _userLinkRepository.AddAsync(mappedUserLink);

        CreatedUserLinkDto response = _mapper.Map<CreatedUserLinkDto>(createdUserLink);

        return response;
    }
}