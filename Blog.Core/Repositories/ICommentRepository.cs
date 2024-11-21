using Blog.Core.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Core.Repositories
{
    /// <summary>
    /// Interface for managing comments in the blog system.
    /// </summary>
    public interface ICommentRepository
    {
        /// <summary>
        /// Retrieves a list of all comments.
        /// </summary>
        /// <returns>A collection of comments.</returns>
        List<Comment> GetList();

        /// <summary>
        /// Retrieves a comment by its ID.
        /// </summary>
        /// <param name="id">The ID of the comment to retrieve.</param>
        /// <returns>The comment with the specified ID, or null if not found.</returns>
        Comment? GetById(int id);

        /// <summary>
        /// Adds a new comment to the system.
        /// </summary>
        /// <param name="comment">The comment to add.</param>
        /// <returns>True if the comment was successfully added, false otherwise.</returns>
        bool Add(Comment comment);

        /// <summary>
        /// Updates an existing comment in the system.
        /// </summary>
        /// <param name="comment">The updated comment information.</param>
        /// <param name="id">The ID of the comment to update.</param>
        /// <returns>True if the comment was successfully updated, false otherwise.</returns>
        bool Update(Comment comment, int id);

        /// <summary>
        /// Deletes a comment from the system.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        /// <returns>True if the comment was successfully deleted, false otherwise.</returns>
        bool Delete(int id);
    }
}

