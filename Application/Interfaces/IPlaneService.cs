using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPlaneService
    {
        IEnumerable<PlaneDto> GetAllPlanes();
        PlaneDto GetPlaneById(int id);

        PlaneDto AddNewPlane(CreatePlaneDto newPlane);
    }
}
