using Application.Interfaces;

namespace WebAPI.Settings
{
    public class AuthenticationSettings : IAuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; }  
    }
}
