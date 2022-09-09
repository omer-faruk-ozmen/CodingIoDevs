using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingIoDevs.Application.Features.UserLinks.Dtos
{
    public class CreatedUserLinkDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedInUrl { get; set; }
    }
}
