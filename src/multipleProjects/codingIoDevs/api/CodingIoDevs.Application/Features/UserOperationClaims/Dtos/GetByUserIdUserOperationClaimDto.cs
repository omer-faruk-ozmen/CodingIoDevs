using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Dtos
{
    public class GetByUserIdUserOperationClaimDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
