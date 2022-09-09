using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQueryValidator : AbstractValidator<GetListProgrammingLanguageQuery>
{
    public GetListProgrammingLanguageQueryValidator()
    {
        RuleFor(l => l.PageRequest.Page).GreaterThanOrEqualTo(0);
        RuleFor(l => l.PageRequest.PageSize).GreaterThanOrEqualTo(0);
    }
}