using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{


    /// <summary>
    /// Interface for managing operations related to categories in the system.
    /// </summary>
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public bool AddCategory(Category category);
        public bool UpdateCategory(int id, Category category);
        public bool DeleteCategory(int id);
    }
}
