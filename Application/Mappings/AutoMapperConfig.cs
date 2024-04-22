using AutoMapper;
using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    /*
     Provides a configuration for AutoMapper to map between different DTOs and entities.
    */
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() =>
        new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Plane, PlaneDto>();
            cfg.CreateMap<CreatePlaneDto, Plane>();
            cfg.CreateMap<UpdatePlaneDto, Plane>();

            cfg.CreateMap<RegisterUserDto, User>();
            cfg.CreateMap<User, RegisterUserDto>();

            cfg.CreateMap<RegisterUserDto, UserDto>();
            cfg.CreateMap<UserDto, RegisterUserDto>();

            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<Role, RoleDto>();
        }).CreateMapper();
    }
}
