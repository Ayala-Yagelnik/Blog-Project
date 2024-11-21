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
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public List<Tag> GetAllTags() => _tagRepository.GetList();

        public Tag GetTagById(int id) => _tagRepository.GetList().FirstOrDefault(x => x.Id == id);

        public bool AddTag(Tag tag)
        {
            return _tagRepository.Add(tag);
        }

        public bool UpdateTag(int id, Tag tag)
        {
            return _tagRepository.Update(tag,id);
        }

        public bool DeleteTag(int id)
        {
            return _tagRepository.Delete(id);
        }
    }

}
