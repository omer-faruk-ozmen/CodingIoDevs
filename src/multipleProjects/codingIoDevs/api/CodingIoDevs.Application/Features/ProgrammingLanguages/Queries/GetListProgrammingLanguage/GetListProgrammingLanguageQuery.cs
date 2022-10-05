using CodingIoDevs.Application.Features.ProgrammingLanguages.Models;
using Core.Application.Requests;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQuery : IRequest<GetListProgrammingLanguageModel>
{
    public PageRequest PageRequest { get; set; }
}