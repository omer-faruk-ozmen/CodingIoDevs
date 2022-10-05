using AutoMapper;
using CodingIoDevs.Application.Features.UserLinks.Commands.CreateUserLink;
using CodingIoDevs.Application.Features.UserLinks.Commands.UpdateUserLink;
using CodingIoDevs.Application.Features.UserLinks.Dtos;
using CodingIoDevs.Domain.Entities;

namespace CodingIoDevs.Application.Features.UserLinks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserLink, CreatedUserLinkDto>().ReverseMap();
        CreateMap<UserLink, CreateUserLinkCommand>().ReverseMap();

        CreateMap<UserLink, UpdateUserLinkCommand>().ReverseMap();

        CreateMap<UserLink, GetByIdUserLinkDto>().ReverseMap();
    }
}