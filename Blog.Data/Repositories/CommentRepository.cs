using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly DataContext _dataContext;

        public CommentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Comment> GetList()
        {
            return _dataContext.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return _dataContext.Comments.FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Comment comment)
        {
            try
            {
                _dataContext.Comments.Add(comment);
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
                Comment comment = GetById(id);
                if (comment == null) return false;

                _dataContext.Comments.Remove(comment);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Comment comment, int id)
        {
            Comment original = GetById(id);
            if (original == null) return false;
            try
            {
                SetFields(original, comment);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetFields(Comment original, Comment updated)
        {
            original.Content = updated.Content;
            original.AuthorId = updated.AuthorId;
            original.PostId = updated.PostId;
            original.CreatedAt = updated.CreatedAt;
        }
    }
}

