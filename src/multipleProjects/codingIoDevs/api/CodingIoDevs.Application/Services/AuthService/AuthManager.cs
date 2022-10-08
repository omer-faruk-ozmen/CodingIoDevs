using CodingIoDevs.Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public AuthManager(ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository, IUserOperationClaimRepository userOperationClaimRepository)
    {
        _tokenHelper = tokenHelper;
        _refreshTokenRepository = refreshTokenRepository;
        _userOperationClaimRepository = userOperationClaimRepository;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u => u.Include(u => u.OperationClaim));

        IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(u => new OperationClaim
        {
            Id = u.OperationClaimId,
            Name = u.OperationClaim.Name
        }).ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);

        return accessToken;
    }

    public async Task<RefreshToken> CreateRefreshToken(User user, string? ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);

        return await Task.FromResult(refreshToken);
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }
}