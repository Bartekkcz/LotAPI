using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        UserDto AddNewUser(RegisterUserDto newUser);
        void UpdateUser(UserDto updateUser);
        void DeleteUser(int id);
    }
}
