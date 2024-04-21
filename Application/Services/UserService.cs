using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        
        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
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

    }
}
