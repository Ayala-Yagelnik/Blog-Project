using Blog.Core.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Core.Repositories
{
    /// <summary>
    /// Interface for managing users in the blog system.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>A collection of users.</returns>
        List<User> GetList();

        /// <summary>
        /// Retrieves a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        User? GetById(int id);

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>True if the user was successfully added, false otherwise.</returns>
        bool Add(User user);

        /// <summary>
        /// Updates an existing user in the system.
        /// </summary>
        /// <param name="user">The updated user information.</param>
        /// <param name="id">The ID of the user to update.</param>
        /// <returns>True if the user was successfully updated, false otherwise.</returns>
        bool Update(User user, int id);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the user was successfully deleted, false otherwise.</returns>
        bool Delete(int id);
    }
}
