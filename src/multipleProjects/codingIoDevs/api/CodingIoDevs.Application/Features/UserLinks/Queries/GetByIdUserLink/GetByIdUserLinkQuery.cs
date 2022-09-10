using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.UserLinks.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.UserLinks.Queries.GetByIdUserLink
{
    public class GetByIdUserLinkQuery : IRequest<GetByIdUserLinkDto>
    {
        public Guid UserId { get; set; }
    }
}
