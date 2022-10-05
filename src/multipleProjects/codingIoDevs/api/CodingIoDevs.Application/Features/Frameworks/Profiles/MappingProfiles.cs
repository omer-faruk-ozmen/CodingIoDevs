using AutoMapper;
using CodingIoDevs.Application.Features.Frameworks.Commands.CreateFramework;
using CodingIoDevs.Application.Features.Frameworks.Commands.UpdateFramework;
using CodingIoDevs.Application.Features.Frameworks.Dtos;
using CodingIoDevs.Application.Features.Frameworks.Models;
using CodingIoDevs.Domain.Entities;
using Core.Persistence.Paging;

namespace CodingIoDevs.Application.Features.Frameworks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Framework, CreatedFrameworkDto>().ReverseMap();
        CreateMap<Framework, CreateFrameworkCommand>().ReverseMap();
        CreateMap<Framework, UpdateFrameworkCommand>().ReverseMap();

        CreateMap<Framework, FrameworkListDto>()
            .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
            .ReverseMap();
        CreateMap<IPaginate<Framework>, FrameworkListModel>().ReverseMap();

    }
}