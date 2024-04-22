using Application.Dto;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public PlaneDto AddNewPlane(CreatePlaneDto newPlane)
        {
            if (string.IsNullOrEmpty(newPlane.FlightNumber))
            {
                throw new Exception("Plane must have a flight number ");
            }

            var plane = _mapper.Map<Plane>(newPlane);
            _planeRepository.Add(plane);
            return _mapper.Map<PlaneDto>(plane);
        }

        public void UpdatePlane(UpdatePlaneDto updatePlane)
        {
            var existingPlane = _planeRepository.GetById(updatePlane.Id);
            var plane = _mapper.Map(updatePlane, existingPlane);
            _planeRepository.Update(plane);
        }

        public void DeletePlane(int id)
        {
            var plane = _planeRepository.GetById(id);
            _planeRepository.Delete(plane);
        }
    }
}
