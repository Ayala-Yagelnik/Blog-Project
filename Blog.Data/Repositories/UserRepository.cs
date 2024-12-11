using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<User> GetList()
        {
            return _dataContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dataContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool Add(User user)
        {
            try
            {
                _dataContext.Users.Add(user);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                User user = GetById(id);
                if (user == null) return false;

                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(User user, int id)
        {
            User original = GetById(id);
            if (original == null) return false;
            try
            {
                SetFields(original, user);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
