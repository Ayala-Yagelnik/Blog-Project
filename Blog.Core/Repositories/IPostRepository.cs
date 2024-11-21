using Blog.Core.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Core.Repositories
{
    /// <summary>
    /// Interface for managing posts in the blog system.
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Retrieves a list of all posts.
        /// </summary>
        /// <returns>A collection of posts.</returns>
        List<Post> GetList();

        /// <summary>
        /// Retrieves a post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <returns>The post with the specified ID, or null if not found.</returns>
        Post? GetById(int id);

        /// <summary>
        /// Adds a new post to the system.
        /// </summary>
        /// <param name="post">The post to add.</param>
        /// <returns>True if the post was successfully added, false otherwise.</returns>
        bool Add(Post post);

        /// <summary>
        /// Updates an existing post in the system.
        /// </summary>
        /// <param name="post">The updated post information.</param>
        /// <param name="id">The ID of the post to update.</param>
        /// <returns>True if the post was successfully updated, false otherwise.</returns>
        bool Update(Post post, int id);

        /// <summary>
        /// Deletes a post from the system.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <returns>True if the post was successfully deleted, false otherwise.</returns>
        bool Delete(int id);
    }
}
