using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Models;
using Core.Application.Requests;
using MediatR;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery : IRequest<GetListProgrammingLanguageModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
