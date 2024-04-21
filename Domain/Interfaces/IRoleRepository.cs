using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetALL();
        Role GetById(int id);
        Role Add(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
