using AutoMapper;
using CMS.UsersMicroservice.Domain.Models;
using CMS.UsersMicroservice.Models.Dto;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace CMS.UsersMicroservice.Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }

    }
}
