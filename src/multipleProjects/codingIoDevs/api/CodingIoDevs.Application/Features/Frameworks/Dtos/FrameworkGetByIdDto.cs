using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingIoDevs.Application.Features.Frameworks.Dtos
{
    public class FrameworkGetByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
