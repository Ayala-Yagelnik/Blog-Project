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
    public class CommentService : ICommentService
    {
        readonly IRepository<Comment> _commentRepository;
        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<Comment> GetAllComments() => _commentRepository.GetList();

        public Comment GetCommentById(int id) => _commentRepository.GetById(id);

        public bool AddComment(Comment comment)
        {
            return _commentRepository.Add(comment);
        }

        public bool UpdateComment(int id, Comment comment)
        {
            return _commentRepository.Update(comment, id);
        }

        public bool DeleteComment(int id)
        {
            return _commentRepository.Delete(id);
        }
    }
}
