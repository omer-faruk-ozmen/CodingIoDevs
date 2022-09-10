using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CodingIoDevs.Application.Features.Frameworks.Commands.UpdateFramework;

public class UpdateFrameworkCommandValidator : AbstractValidator<UpdateFrameworkCommand>
{
    public UpdateFrameworkCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.Name).NotEmpty().MinimumLength(1);
        RuleFor(p => p.ProgrammingLanguageId).NotEmpty();
    }
}