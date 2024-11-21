using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using Blog.Core.Services;

namespace Blog.Data.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Category> GetList()
        {
            return _dataContext.CategoryData;
        }

        public Category GetById(int id)
        {
            return _dataContext.CategoryData.FirstOrDefault(v => v.Id == id);
        }

        public bool Add(Category category)
        {
            category.Id = _dataContext.CategoryData.Any()
                ? _dataContext.CategoryData.Max(v => v.Id) + 1
                : 1;

            _dataContext.CategoryData.Add(category);
            return _dataContext.SaveCategoryData();
        }

        public bool Delete(int id)
        {
            Category category = GetById(id);
            if (category == null) return false;

            _dataContext.CategoryData.Remove(category);
            return _dataContext.SaveCategoryData();
        }

        private void SetFields(Category original, Category updated)
        {
            original.Name = updated.Name;
            original.ParentID = updated.ParentID;
            original.Description = updated.Description;
        }

        public bool Update( Category category,int id)
        {
            Category original = GetById(id);
            if (original == null) return false;

            SetFields(original, category);
            return _dataContext.SaveCategoryData();
        }

    }
}