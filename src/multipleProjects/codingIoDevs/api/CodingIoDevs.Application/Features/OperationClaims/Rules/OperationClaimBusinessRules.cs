using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace CodingIoDevs.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimShouldNotDuplicatedWhenInserted(string roleName)
        {
            var result = await _operationClaimRepository.GetAsync(o => o.Name == roleName);

            if (result != null)
                throw new BusinessException("This role already exists");
        }

        public void OperationClaimMustNotBeEmpty(OperationClaim operationClaim)
        {
            if (operationClaim is null)
                throw new BusinessException("This role does not exist");
        }

    }
}
