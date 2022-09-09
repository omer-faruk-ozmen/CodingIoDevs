using System.ComponentModel;
using AutoMapper;
using CodingIoDevs.Application.Features.Auth.Dtos;
using CodingIoDevs.Application.Features.Auth.Rules;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace CodingIoDevs.Application.Features.Auth.Commands.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
{
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserRepository _userRepository;
    private readonly AuthBusinessRules _authBusinessRules;

    public RegisterUserCommandHandler(IMapper mapper, ITokenHelper tokenHelper, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
    {
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<RegisterUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.EmailAddressCanNotBeDuplicatedWhenInserted(request.Email);



        HashingHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);



        User mappedUser = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpper(),
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true,
            AuthenticatorType = AuthenticatorType.Email
        };

        User createdUser = await _userRepository.AddAsync(mappedUser);

        IList<OperationClaim> claims = _userRepository.GetClaims(mappedUser);

        AccessToken token = _tokenHelper.CreateToken(mappedUser, claims);


        return new() { Token = token.Token, Expiration = token.Expiration };
    }
}