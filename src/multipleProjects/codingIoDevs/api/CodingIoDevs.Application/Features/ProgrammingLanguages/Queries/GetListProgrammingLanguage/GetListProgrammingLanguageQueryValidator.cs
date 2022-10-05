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