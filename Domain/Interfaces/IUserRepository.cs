using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetALL();
        User GetById(int id);
        User Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
