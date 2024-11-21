using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetList();
        Category? GetById(int id);
        bool Add(Category category);
        bool Update(Category category,int id);
        bool Delete(int id);
    }
}