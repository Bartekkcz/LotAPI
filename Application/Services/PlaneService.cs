using Application.Dto;
using Application.Interfaces;
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
        public PlaneService(IPlaneRepository planeRepository)
        {
            _planeRepository = planeRepository;
        }
        public IEnumerable<PlaneDto> GetAllPlanes()
        {
            var planes = _planeRepository.GetALL();
            return planes.Select(plane => new PlaneDto
            {
                Id = plane.Id,
                FlightNumber = plane.FlightNumber,
                DepartureDate = plane.DepartureDate,
                DeparturePlace = plane.DeparturePlace,
                ArrivalPlace = plane.ArrivalPlace,
                PlaneType = plane.PlaneType
            });
        }

        public PlaneDto GetPlaneById(int id)
        {
            var plane = _planeRepository.GetById(id);
            return new PlaneDto()
            {
                Id = plane.Id,
                FlightNumber = plane.FlightNumber,
                DepartureDate = plane.DepartureDate,
                DeparturePlace = plane.DeparturePlace,
                ArrivalPlace = plane.ArrivalPlace,
                PlaneType = plane.PlaneType
            };
        }
    }
}
