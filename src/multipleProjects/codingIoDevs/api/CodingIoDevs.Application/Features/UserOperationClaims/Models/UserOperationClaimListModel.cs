using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModel : BasePageableModel
    {
        public IList<ListUserOperationClaimDto> Items { get; set; }
    }
}
