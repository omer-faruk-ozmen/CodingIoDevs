using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Models;

public class UserOperationClaimListModel : BasePageableModel
{
    public IList<ListUserOperationClaimDto> Items { get; set; }
}