using AutoMapper;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using CodingIoDevs.Application.Features.OperationClaims.Models;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace CodingIoDevs.Application.Features.OperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, ListOperationClaimDto>().ReverseMap();
        CreateMap<OperationClaimListModel, ListOperationClaimDto>().ReverseMap();
        CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
    }
}