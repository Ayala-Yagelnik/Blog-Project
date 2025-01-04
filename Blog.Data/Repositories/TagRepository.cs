using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly DataContext _dataContext;

        public TagRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Tag> GetList()
        {
            return _dataContext.Tags.ToList();
        }

        public Tag GetById(int id)
        {
            return _dataContext.Tags.FirstOrDefault(t => t.Id == id);
        }

        public bool Add(Tag tag)
        {
            try
            {
                _dataContext.Tags.Add(tag);
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
                Tag tag = GetById(id);
                if (tag == null) return false;

                _dataContext.Tags.Remove(tag);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Tag tag, int id)
        {
            Tag original = GetById(id);
            if (original == null) return false;
            try
            {
                SetFields(original, tag);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetFields(Tag original, Tag updated)
        {
            original.Name = updated.Name;
            original.UsageAmount = updated.UsageAmount;
            original.Description = updated.Description;
            original.Author = updated.Author;
            original.IsActive = updated.IsActive;
        }
    }
}
