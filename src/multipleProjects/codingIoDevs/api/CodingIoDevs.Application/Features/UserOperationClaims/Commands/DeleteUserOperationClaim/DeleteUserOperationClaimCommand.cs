using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using CodingIoDevs.Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
    {
        public Guid UserOperationClaimId { get; set; }
    }

    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            await _userOperationClaimRepository.DeleteAsync(request.UserOperationClaimId);

            return new();
        }
    }
}
