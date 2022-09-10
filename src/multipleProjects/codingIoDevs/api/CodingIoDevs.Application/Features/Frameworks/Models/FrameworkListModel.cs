using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.Frameworks.Dtos;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.Frameworks.Models;

public class FrameworkListModel : BasePageableModel
{
    public IList<FrameworkListDto> Items { get; set; }
}