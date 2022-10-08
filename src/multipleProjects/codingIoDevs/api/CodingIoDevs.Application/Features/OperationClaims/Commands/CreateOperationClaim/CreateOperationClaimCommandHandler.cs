using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = new()
            {
                Name = request.RoleName
            };

            await _operationClaimRepository.AddAsync(operationClaim);
            return new();
        }
    }
}
