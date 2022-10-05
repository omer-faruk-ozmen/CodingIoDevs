using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Models;

public class GetListProgrammingLanguageModel : BasePageableModel
{
    public IList<GetListProgrammingLanguageDto> Items { get; set; }
}