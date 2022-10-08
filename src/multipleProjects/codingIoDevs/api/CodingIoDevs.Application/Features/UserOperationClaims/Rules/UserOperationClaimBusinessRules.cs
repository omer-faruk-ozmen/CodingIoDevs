using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserRepository _userRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task UserShouldExist(Guid userId)
        {
            User? result = await _userRepository.GetAsync(u => u.Id == userId);
            if (result is null)
                throw new BusinessException("User not found");
        }

        public async Task OperationClaimShouldExist(Guid operationClaimId)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(o => o.Id == operationClaimId);
            if (result is null)
                throw new BusinessException("Operation Claim not found");
        }

        public async Task RolesCanBeAddedOncePerUser(UserOperationClaim userOperationClaim)
        {
            var result= await _userOperationClaimRepository.GetListAsync(u => u.User.Id == userOperationClaim.UserId, include: m => m.Include(u => u.OperationClaim).Include(p => p.User));

            foreach (var items in result.Items)
            {
                if (items.OperationClaim.Id == userOperationClaim.OperationClaimId)
                {
                    throw new BusinessException("Already added to this role for the user");
                }
            }
        }
    }
}
