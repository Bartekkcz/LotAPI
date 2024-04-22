using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAuthenticationSettings _authenticationSettings;
        
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher, IAuthenticationSettings authenticationSettings) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetALL();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }
        public UserDto AddNewUser(RegisterUserDto newUser)
        {
            if (string.IsNullOrEmpty(newUser.Email) && string.IsNullOrEmpty(newUser.PasswordHash))
            {
                throw new Exception("User must have an e-mail and a password ");
            }
            var user = _mapper.Map<User>(newUser);

            var hashedPassword = _passwordHasher.HashPassword(user, newUser.PasswordHash);
            user.PasswordHash = hashedPassword;

            _userRepository.Add(user);
            return _mapper.Map<UserDto>(newUser);
        }
        public void UpdateUser(UserDto updateUser)
        {
            var existingUser = _userRepository.GetById(updateUser.Id);
            var user = _mapper.Map(updateUser, existingUser);
            _userRepository.Update(user);
        }
        public void DeleteUser(int id)
        {
            var existingUser = _userRepository.GetById(id);
            _userRepository.Delete(existingUser);
        }

        public string GenerateJwt(LoginDto loginUser)
        {
            var user = _userRepository.GetALL().FirstOrDefault(u => u.Email == loginUser.Email);
            if (user is null)
            {
                throw new Exception("Invalid username or password!");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid password!");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, $"{user.Email}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
