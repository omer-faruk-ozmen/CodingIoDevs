using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.OperationClaims.Models;

public class OperationClaimListModel :BasePageableModel
{
    public IList<ListOperationClaimDto> Items { get; set; }
}