using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CodingIoDevs.Application.Features.UserLinks.Commands.CreateUserLink
{
    public class CreateUserLinkCommandValidator :AbstractValidator<CreateUserLinkCommand>
    {
        public CreateUserLinkCommandValidator()
        {
            
        }
    }
}
