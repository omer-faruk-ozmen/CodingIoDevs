using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.DeleteFramework
{
    public class DeleteFrameworkCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
