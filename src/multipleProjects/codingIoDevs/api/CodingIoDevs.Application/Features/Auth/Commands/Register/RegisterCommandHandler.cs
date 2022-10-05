using AutoMapper;
using CodingIoDevs.Application.Features.Auth.Dtos;
using CodingIoDevs.Application.Features.Auth.Rules;
using CodingIoDevs.Application.Services.AuthService;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace CodingIoDevs.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    private readonly AuthBusinessRules _authBusinessRules;

    public RegisterCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService)
    {
        _userRepository = userRepository;
        _authBusinessRules = authBusinessRules;
        _authService = authService;
    }

    public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.EmailAddressCanNotBeDuplicatedWhenInserted(request.UserForRegisterDto.Email);



        HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);



        User mappedUser = new User
        {
            FirstName = request.UserForRegisterDto.FirstName,
            LastName = request.UserForRegisterDto.LastName,
            Email = request.UserForRegisterDto.Email,
            NormalizedEmail = request.UserForRegisterDto.Email.ToUpper(),
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        User createdUser = await _userRepository.AddAsync(mappedUser);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);

        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        RegisteredDto registeredDto = new()
        {
            RefreshToken = addedRefreshToken,
            AccessToken = createdAccessToken
        };

        return registeredDto;
    }
}