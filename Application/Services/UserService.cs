﻿using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public IEnumerable<UserDto> GetAllPlanes()
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