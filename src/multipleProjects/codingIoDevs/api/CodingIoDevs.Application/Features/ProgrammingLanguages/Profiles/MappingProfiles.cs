using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using CodingIoDevs.Domain.Entities;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        }
    }
}
