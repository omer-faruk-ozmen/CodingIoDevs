using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Models;

public class UserOperationClaimSingleModel :BasePageableModel
{
    public IList<GetByUserIdUserOperationClaimDto> Items { get; set; }
}