using Blog.Core.Entities;
using Blog.Core.Repositories;
using Blog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class CategoryService : ICategoryService
    {
        readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAllCategories() => _categoryRepository.GetList();
        public Category GetCategoryById(int id) => _categoryRepository.GetById(id);
        public bool AddCategory(Category category)
        {
            return _categoryRepository.Add(category);
        }
        public bool UpdateCategory(int id, Category category)
        {
            return _categoryRepository.Update(category, id);
        }
        public bool DeleteCategory(int id)
        {
            return _categoryRepository.Delete(id);
        }
    }
}
