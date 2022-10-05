using AutoMapper;
using CodingIoDevs.Application.Features.Auth.Dtos;
using CodingIoDevs.Application.Features.Auth.Rules;
using CodingIoDevs.Application.Services.AuthService;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace CodingIoDevs.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
{
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    private readonly AuthBusinessRules _authBusinessRules;

    public LoginCommandHandler(IMapper mapper, ITokenHelper tokenHelper, IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService)
    {
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
        _authBusinessRules = authBusinessRules;
        _authService = authService;
    }

    public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _authBusinessRules.UserControlCorrespondingToEmailAddress(request.UserForLoginDto.Email);

        await _authBusinessRules.PasswordVerification(request.UserForLoginDto.Password, user);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);

        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        return new()
        {
            RefreshToken = addedRefreshToken,
            AccessToken = createdAccessToken
        };
    }
}