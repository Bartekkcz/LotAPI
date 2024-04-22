using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly PlanesContext _context;

        public PlaneRepository(PlanesContext context)
        {
            _context = context;
        }

        public IEnumerable<Domain.Entities.Plane> GetALL()
        {
            return _context.Planes;
        }

        public Domain.Entities.Plane GetById(int id)
        {
            return _context.Planes.SingleOrDefault(x => x.Id == id);
        }

        public Domain.Entities.Plane Add(Domain.Entities.Plane plane)
        {
            plane.Created = DateTime.UtcNow;
            _context.Planes.Add(plane);
            _context.SaveChanges();
            return plane;
        }

        public void Update(Domain.Entities.Plane plane)
        {
            plane.LastModified = DateTime.UtcNow;
            _context.Entry(plane).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Domain.Entities.Plane plane)
        {
            _context.Planes.Remove(plane);
            _context.SaveChanges();
        }
    }
}
