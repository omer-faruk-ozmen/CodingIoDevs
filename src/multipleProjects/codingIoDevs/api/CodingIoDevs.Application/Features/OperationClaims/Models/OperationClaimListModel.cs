using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.Frameworks.Dtos;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel :BasePageableModel
    {
        public IList<ListOperationClaimDto> Items { get; set; }
    }
}
