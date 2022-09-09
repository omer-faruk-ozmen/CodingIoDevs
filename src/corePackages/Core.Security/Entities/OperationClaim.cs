using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class OperationClaim : Entity
    {
        public string Name { get; set; }

        public OperationClaim()
        {

        }

        public OperationClaim(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
