using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Dtos;
using CodingIoDevs.Application.Features.ProgrammingLanguages.Models;
using CodingIoDevs.Domain.Entities;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, GetListProgrammingLanguageModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetListProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

        }
    }
}
