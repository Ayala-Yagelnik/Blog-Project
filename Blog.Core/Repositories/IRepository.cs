using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetList();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity, int id);
        bool Delete(int id);
    }
}
