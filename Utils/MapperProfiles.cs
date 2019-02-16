﻿using AutoMapper;
using GFShop.DataAccessLayer.Entities;
using GFStore.ApplicationLayer.Dto;
using GFStore.ApplicationLayer.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFStore.Utils
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //DTO to Domain
            CreateMap<UserDto, User>()
                .ForMember(x => x.PasswordHash, opt => opt.Ignore())
                .ForMember(x => x.PasswordSalt, opt => opt.Ignore())
                .ForMember(x => x.Role, opt => opt.Ignore());


            //Domain to DTO
            CreateMap<User, UserCreatedResponse>()
                .ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<User, UserDto>()
                 .ForMember(x => x.Password, opt => opt.Ignore());

        }

        
    }
}