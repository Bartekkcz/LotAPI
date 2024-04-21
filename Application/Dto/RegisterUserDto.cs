using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
