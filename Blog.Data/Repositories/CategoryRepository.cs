using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using Blog.Core.Services;

namespace Blog.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Category> GetList()
        {
            return _dataContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _dataContext.Categories.FirstOrDefault(v => v.Id == id);
        }

        public bool Add(Category category)
        {
            try
            {
                _dataContext.Categories.Add(category);
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
                Category category = GetById(id);
                if (category == null) return false;

                _dataContext.Categories.Remove(category);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    
        public bool Update(Category category, int id)
        {
            Category original = GetById(id);
            if (original == null) return false;
            try
            {
                SetFields(original, category);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void SetFields(Category original, Category updated)
        {
            original.Name = updated.Name;
            original.ParentID = updated.ParentID;
            original.Description = updated.Description;
        }

    }
}