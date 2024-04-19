using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private static readonly ISet<Domain.Entities.Plane> _planes = new HashSet<Domain.Entities.Plane>()
        {
            new Domain.Entities.Plane(1, "LO123", DateTime.UtcNow, "Warszawa", "Berlin", "Boeing 787 Dreamliner"),
            new Domain.Entities.Plane(2, "LO456", DateTime.UtcNow, "Kraków", "Amsterdam", "Embraer 195"),
            new Domain.Entities.Plane(3, "LO789", DateTime.UtcNow, "Gdańsk", "Londyn", "Boeing 737-800")
        };

        public IEnumerable<Domain.Entities.Plane> GetALL()
        {
            return _planes;
        }

        public Domain.Entities.Plane GetById(int id)
        {
            return _planes.SingleOrDefault(x => x.Id == id);
        }

        public Domain.Entities.Plane Add(Domain.Entities.Plane plane)
        {
            plane.Id = _planes.Count() + 1;
            plane.Created = DateTime.UtcNow;
            _planes.Add(plane);
            return plane;
        }

        public void Update(Domain.Entities.Plane plane)
        {
            plane.LastModified = DateTime.UtcNow;
        }

        public void Delete(Domain.Entities.Plane plane)
        {
            _planes.Remove(plane);
        }
    }
}
