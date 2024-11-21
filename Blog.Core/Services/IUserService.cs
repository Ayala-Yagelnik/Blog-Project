using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
        /// <summary>
        /// Interface for managing operations related to users in the system.
        /// </summary>
        public interface IUserService
        {
            public List<User> GetAllUsers();
            public User GetUserById(int id);
            public bool AddUser(User user);
            public bool UpdateUser(int id, User user);
            public bool DeleteUser(int id);
        }
    }

