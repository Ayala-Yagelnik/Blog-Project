using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _dataContext;

        public PostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Post> GetList()
        {
            return _dataContext.PostData;
        }

        public Post GetById(int id)
        {
            return _dataContext.PostData.FirstOrDefault(p => p.Id == id);
        }

        public bool Add(Post post)
        {
            post.Id = _dataContext.PostData.Any() ? _dataContext.PostData.Max(p => p.Id) + 1 : 1;

            _dataContext.PostData.Add(post);
            return _dataContext.SavePostData();
        }

        public bool Delete(int id)
        {
            Post post = GetById(id);
            if (post == null) return false;

            _dataContext.PostData.Remove(post);
            return _dataContext.SavePostData();
        }

        public bool Update( Post post,int id)
        {
            Post original = GetById(id);
            if (original == null) return false;

            SetFields(original, post);
            return _dataContext.SavePostData();
        }

        private void SetFields(Post original, Post updated)
        {
            original.Title = updated.Title;
            original.Content = updated.Content;
            original.AuthorId = updated.AuthorId;
            original.CategoryId = updated.CategoryId;
            original.CreatedAt = updated.CreatedAt;
            original.Tags = updated.Tags;
            original.ViewsAmount = updated.ViewsAmount;
            original.Image = updated.Image;
            original.LastUpdatedAt = updated.LastUpdatedAt;
            original.LastViewedAt = updated.LastViewedAt;
        }
    }
}
