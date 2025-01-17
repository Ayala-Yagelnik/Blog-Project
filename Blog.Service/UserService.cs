﻿using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers() => _userRepository.GetList();

        public User GetUserById(int id) => _userRepository.GetById(id);

        public bool AddUser(User user)
        {
            return _userRepository.Add(user);
        }

        public bool UpdateUser(int id, User user)
        {
            return _userRepository.Update( user,id);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}
