using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{

        /// <summary>
        /// Interface for managing operations related to comments in the system.
        /// </summary>
        public interface ICommentService
        {
            public List<Comment> GetAllComments();
            public Comment GetCommentById(int id);
            public bool AddComment(Comment comment);
            public bool UpdateComment(int id, Comment comment);
            public bool DeleteComment(int id);
        
    }
}
