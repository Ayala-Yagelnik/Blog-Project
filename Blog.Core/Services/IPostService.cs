using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{

        /// <summary>
        /// Interface for managing operations related to posts in the system.
        /// </summary>
        public interface IPostService
        {
            public List<Post> GetAllPosts();
            public Post GetPostById(int id);
            public bool AddPost(Post post);
            public bool UpdatePost(int id, Post post);
            public bool DeletePost(int id);
        }
    }

