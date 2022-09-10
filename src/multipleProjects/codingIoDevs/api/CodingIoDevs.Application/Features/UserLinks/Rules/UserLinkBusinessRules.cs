using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Services.Repositories;
using CodingIoDevs.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;

namespace CodingIoDevs.Application.Features.UserLinks.Rules
{
    public class UserLinkBusinessRules
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IUserLinkRepository _userLinkRepository;

        public UserLinkBusinessRules(IUserLinkRepository userLinkRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userLinkRepository = userLinkRepository;
            _httpContextAccessor = httpContextAccessor;
        }


        public Task<Guid> IdOfTheAuthenticatedUser()
        {

            string? userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                throw new BusinessException("Unauthorized operation or unexpected error encountered");

            return Task.FromResult(Guid.Parse(userId));
        }

        public async Task EachUserCanHaveOnlyOneLinkArray(Guid userId)
        {
            UserLink? result = await _userLinkRepository.GetAsync(p => p.UserId == userId);

            if (result != null)
                throw new BusinessException("Links have already been created for this user. Please update the links.");
        }

        public void UserLinkShouldExistWhenRequested(UserLink? dbUserLink)
        {
            if (dbUserLink == null) throw new BusinessException("Requested User link does not exists");
        }
    }
}
