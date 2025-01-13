using TaskFlow.Server.Models;

namespace TaskFlow.Server.Services
{
    public interface IUsersService
    {
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        Task<IEnumerable<Users>> GetAllUsersAsync();

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID.</returns>
        Task<Users> GetUserByIdAsync(long id);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>The newly created user.</returns>
        Task<Users> CreateUserAsync(Users user);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The user with updated details.</param>
        /// <returns>The updated user.</returns>
        Task<Users> UpdateUserAsync(Users user);

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteUserAsync(long id);
    }
}