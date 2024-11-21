using Blog.Data;
using Blog.Core.Entities;
using Blog.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
    {
        public class CommentRepository : ICommentRepository
        {
            private readonly DataContext _dataContext;

            public CommentRepository(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public List<Comment> GetList()
            {
                return _dataContext.CommentData;
            }

            public Comment GetById(int id)
            {
                return _dataContext.CommentData.FirstOrDefault(c => c.Id == id);
            }

            public bool Add(Comment comment)
            {
                comment.Id = _dataContext.CommentData.Any() ? _dataContext.CommentData.Max(c => c.Id) + 1 : 1;

                _dataContext.CommentData.Add(comment);
                return _dataContext.SaveCommentData();
            }

            public bool Delete(int id)
            {
                Comment comment = GetById(id);
                if (comment == null) return false;

                _dataContext.CommentData.Remove(comment);
                return _dataContext.SaveCommentData();
            }

            public bool Update( Comment comment,int id)
            {
                Comment original = GetById(id);
                if (original == null) return false;

                SetFields(original, comment);
                return _dataContext.SaveCommentData();
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

