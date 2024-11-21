using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _dataContext;

        public TagRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Tag> GetList()
        {
            return _dataContext.TagData;
        }

        public Tag GetById(int id)
        {
            return _dataContext.TagData.FirstOrDefault(t => t.Id == id);
        }

        public bool Add(Tag tag)
        {
            tag.Id = _dataContext.TagData.Any() ? _dataContext.TagData.Max(t => t.Id) + 1 : 1;

            _dataContext.TagData.Add(tag);
            return _dataContext.SaveTagData();
        }

        public bool Delete(int id)
        {
            Tag tag = GetById(id);
            if (tag == null) return false;

            _dataContext.TagData.Remove(tag);
            return _dataContext.SaveTagData();
        }

        public bool Update(Tag tag, int id)
        {
            Tag original = GetById(id);
            if (original == null) return false;

            SetFields(original, tag);
            return _dataContext.SaveTagData();
        }

        private void SetFields(Tag original, Tag updated)
        {
            original.Name = updated.Name;
            original.UsageAmount = updated.UsageAmount;
            original.Description = updated.Description;
            original.CreatorId = updated.CreatorId;
            original.IsActive = updated.IsActive;
        }
    }
}
