﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CodingIoDevs.Application.Features.OperationClaims.Dtos;
using CodingIoDevs.Application.Features.UserOperationClaims.Dtos;
using CodingIoDevs.Application.Features.UserOperationClaims.Models;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace CodingIoDevs.Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, ListUserOperationClaimDto>().ForMember(p => p.Name, opt => opt.MapFrom(p => p.OperationClaim.Name)).ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.User.FirstName)).ForMember(p => p.LastName, opt => opt.MapFrom(p => p.User.LastName)).ReverseMap();
            CreateMap<UserOperationClaimListModel, ListUserOperationClaimDto>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();


            CreateMap<UserOperationClaim, GetByUserIdUserOperationClaimDto>().ForMember(p => p.Name, opt => opt.MapFrom(p => p.OperationClaim.Name)).ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.User.FirstName)).ForMember(p => p.LastName, opt => opt.MapFrom(p => p.User.LastName)).ReverseMap();
            CreateMap<UserOperationClaimSingleModel, GetByUserIdUserOperationClaimDto>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimSingleModel>().ReverseMap();

        }
    }
}