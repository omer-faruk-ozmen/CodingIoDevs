using CodingIoDevs.Application.Features.OperationClaims.Models;
using Core.Application.Requests;
using MediatR;

namespace CodingIoDevs.Application.Features.OperationClaims.Queries.GetListOperationClaim;

public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
{
    public PageRequest PageRequest { get; set; }
}