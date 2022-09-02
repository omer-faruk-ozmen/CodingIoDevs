using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            
        }

        public Entity(Guid id) :this()
        {
            Id = id;
        }
    }
}
