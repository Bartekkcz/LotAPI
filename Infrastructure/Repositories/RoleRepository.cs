using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /*  Represents the repository for interacting with role entities in the database  */
    public class RoleRepository : IRoleRepository
    {
        private readonly PlanesContext _context;
        public RoleRepository(PlanesContext context)
        {
            _context = context;
        }
        public IEnumerable<Role> GetALL()
        {
            return _context.Roles;
        }
        public Role GetById(int id)
        {
            return _context.Roles.SingleOrDefault(x => x.Id == id);
        }
        public Role Add(Role role)
        {
            role.Created = DateTime.UtcNow;
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }
        public void Update(Role role)
        {
            role.LastModified = DateTime.UtcNow;
        }
        public void Delete(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}
