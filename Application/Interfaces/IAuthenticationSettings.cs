using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthenticationSettings
    {
        public string JwtKey { get; }
        public int JwtExpireDays { get; }
        public string JwtIssuer { get; }
    }
}
