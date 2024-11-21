using Blog.Core.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Core.Repositories
{
    /// <summary>
    /// Interface for managing tags in the blog system.
    /// </summary>
    public interface ITagRepository
    {
        /// <summary>
        /// Retrieves a list of all tags.
        /// </summary>
        /// <returns>A collection of tags.</returns>
        List<Tag> GetList();

        /// <summary>
        /// Retrieves a tag by its ID.
        /// </summary>
        /// <param name="id">The ID of the tag to retrieve.</param>
        /// <returns>The tag with the specified ID, or null if not found.</returns>
        Tag? GetById(int id);

        /// <summary>
        /// Adds a new tag to the system.
        /// </summary>
        /// <param name="tag">The tag to add.</param>
        /// <returns>True if the tag was successfully added, false otherwise.</returns>
        bool Add(Tag tag);

        /// <summary>
        /// Updates an existing tag in the system.
        /// </summary>
        /// <param name="tag">The updated tag information.</param>
        /// <param name="id">The ID of the tag to update.</param>
        /// <returns>True if the tag was successfully updated, false otherwise.</returns>
        bool Update(Tag tag, int id);

        /// <summary>
        /// Deletes a tag from the system.
        /// </summary>
        /// <param name="id">The ID of the tag to delete.</param>
        /// <returns>True if the tag was successfully deleted, false otherwise.</returns>
        bool Delete(int id);
    }
}

