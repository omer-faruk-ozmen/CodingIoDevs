using CodingIoDevs.Application.Features.Frameworks.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.Frameworks.Models;

public class FrameworkListModel : BasePageableModel
{
    public IList<FrameworkListDto> Items { get; set; }
}