using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
   
        /// <summary>
        /// Interface for managing operations related to tags in the system.
        /// </summary>
        public interface ITagService
        {
            public List<Tag> GetAllTags();
            public Tag GetTagById(int id);
            public bool AddTag(Tag tag);
            public bool UpdateTag(int id, Tag tag);
            public bool DeleteTag(int id);
        }
    }
