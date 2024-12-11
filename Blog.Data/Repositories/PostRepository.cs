using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private readonly DataContext _dataContext;

        public PostRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Post> GetList()
        {
            return _dataContext.Posts.ToList();
        }

        public Post GetById(int id)
        {
            return _dataContext.Posts.FirstOrDefault(p => p.Id == id);
        }

        public bool Add(Post post)
        {
            try
            {
                _dataContext.Posts.Add(post);
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
                Post post = GetById(id);
                if (post == null) return false;

                _dataContext.Posts.Remove(post);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Post post, int id)
        {
            Post original = GetById(id);
            if (original == null) return false;
            try
            {
                SetFields(original, post);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
