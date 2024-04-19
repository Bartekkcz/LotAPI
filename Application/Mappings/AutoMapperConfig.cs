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
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() =>
            new MapperConfiguration(cfg =>
                cfg.CreateMap<Plane, PlaneDto>()
            ).CreateMapper();
    }
}
