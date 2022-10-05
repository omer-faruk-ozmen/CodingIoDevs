using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLanguageQuery : IRequest<GetByIdProgrammingLanguageDto>
{
    public Guid Id { get; set; }
}