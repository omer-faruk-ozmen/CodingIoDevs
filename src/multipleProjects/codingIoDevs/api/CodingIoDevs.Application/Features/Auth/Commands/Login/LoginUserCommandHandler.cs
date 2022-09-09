using AutoMapper;
using CodingIoDevs.Application.Features.Auth.Dtos;
using CodingIoDevs.Application.Features.Auth.Rules;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;

namespace CodingIoDevs.Application.Features.Auth.Commands.Login;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDto>
{
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserRepository _userRepository;
    private readonly AuthBusinessRules _authBusinessRules;

    public LoginUserCommandHandler(IMapper mapper, ITokenHelper tokenHelper, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
    {
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _authBusinessRules.UserControlCorrespondingToEmailAddress(request.Email);

        await _authBusinessRules.PasswordVerification(request.Password, user);

        var claims = _userRepository.GetClaims(user);

        var token = _tokenHelper.CreateToken(user, claims);

        return new() { Token = token.Token, Expiration = token.Expiration };

    }
}