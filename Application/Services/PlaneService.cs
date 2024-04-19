﻿using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly IPlaneRepository _planeRepository;
        private readonly IMapper _mapper;
        public PlaneService(IPlaneRepository planeRepository, IMapper mapper)
        {
            _planeRepository = planeRepository;
            _mapper = mapper;
        }
        public IEnumerable<PlaneDto> GetAllPlanes()
        {
            var planes = _planeRepository.GetALL();
            return _mapper.Map<IEnumerable<PlaneDto>>(planes);
        }

        public PlaneDto GetPlaneById(int id)
        {
            var plane = _planeRepository.GetById(id);
            return _mapper.Map<PlaneDto>(plane);
        }
    }
}
