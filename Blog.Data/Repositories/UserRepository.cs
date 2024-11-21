using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<User> GetList()
        {
            return _dataContext.UserData;
        }

        public User GetById(int id)
        {
            return _dataContext.UserData.FirstOrDefault(u => u.Id == id);
        }

        public bool Add(User user)
        {
            user.Id = _dataContext.UserData.Any() ? _dataContext.UserData.Max(u => u.Id) + 1 : 1;

            _dataContext.UserData.Add(user);
            return _dataContext.SaveUserData();
        }

        public bool Delete(int id)
        {
            User user = GetById(id);
            if (user == null) return false;

            _dataContext.UserData.Remove(user);
            return _dataContext.SaveUserData();
        }

        public bool Update(User user, int id)
        {
            User original = GetById(id);
            if (original == null) return false;

            SetFields(original, user);
            return _dataContext.SaveUserData();
        }

        private void SetFields(User original, User updated)
        {
            original.Name = updated.Name;
            original.Email = updated.Email;
            original.Password = updated.Password;
            original.PhoneNumber = updated.PhoneNumber;
            original.Country = updated.Country;
            original.Icon = updated.Icon;
            original.Bio = updated.Bio;
            original.RegistrationDate = updated.RegistrationDate;
        }
    }
}
