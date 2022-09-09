using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class EmailAuthenticator : Entity
    {
        public Guid UserId { get; set; }
        public string? ActivationKey { get; set; }
        public bool IsVerified { get; set; }
        public User User { get; set; }

        public EmailAuthenticator()
        {

        }

        public EmailAuthenticator(Guid id, Guid userId, string? activationKey, bool isVerified) : this()
        {
            Id = id;
            UserId = userId;
            ActivationKey = activationKey;
            IsVerified = isVerified;
        }
    }
}
