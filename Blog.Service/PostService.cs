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
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> GetAllPosts() => _postRepository.GetList();

        public Post GetPostById(int id) => _postRepository.GetById(id);

        public bool AddPost(Post post)
        {
            return _postRepository.Add(post);
        }

        public bool UpdatePost(int id, Post post)
        {
            return _postRepository.Update(post, id);
        }

        public bool DeletePost(int id)
        {
            return _postRepository.Delete(id);
        }
    }
}
