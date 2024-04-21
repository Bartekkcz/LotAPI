using Azure;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PlanesContext _context;
        public UserRepository(PlanesContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetALL()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }
        public User Add(User user)
        {
            user.Created = DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public void Update(User user)
        {
            user.LastModified = DateTime.UtcNow;
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
