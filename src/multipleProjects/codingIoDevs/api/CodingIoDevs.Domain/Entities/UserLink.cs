using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace CodingIoDevs.Domain.Entities
{
    public class UserLink : Entity
    {
        public Guid UserId { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public virtual User User { get; set; }

        public UserLink()
        {

        }

        public UserLink(Guid id, Guid userId, string? githubUrl, string? linkedInUrl) : this()
        {
            Id = id;
            UserId = userId;
            GithubUrl = githubUrl;
            LinkedInUrl = linkedInUrl;
        }
    }
}
