using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPlaneRepository
    {
        IEnumerable<Plane> GetALL();
        Plane GetById(int id);
        Plane Add(Plane plane);
        void Update(Plane plane);
        void Delete(Plane plane);
    }
}
