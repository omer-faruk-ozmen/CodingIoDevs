using CodingIoDevs.Application.Features.ProgrammingLanguages.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListLanguageByDynamicQuery;

public class GetListLanguageDynamicQuery : IRequest<GetListProgrammingLanguageModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
}