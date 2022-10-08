using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimSingleModel :BasePageableModel
    {
        public IList<GetByUserIdUserOperationClaimDto> Items { get; set; }
    }
}
