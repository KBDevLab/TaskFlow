using TaskFlow.Server.Models;
using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Exceptions;

namespace  TaskFlow.Server.Services
{
    public class UsersService : IUsersService
{
    private readonly IUsersRepository _userRepository;

    public UsersService(IUsersRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // Example: Method to get all users with some business logic
    public async Task<IEnumerable<Users>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    // Example: Method to get a user by ID, with additional checks
    public async Task<Users> GetUserByIdAsync(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {id} not found.");
        }
        return user;
    }

    // Example: Method to create a new user, with validation
    public async Task<Users> CreateUserAsync(Users user)
    {
        // Business logic: Validate user data
        if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Email))
        {
            throw new ArgumentException("Username and Email are required.");
        }

        // Check if the username or email already exists
        var existingUserByUsername = await _userRepository.GetUserByUsernameAsync(user.Username);
        if (existingUserByUsername != null)
        {
            throw new ArgumentException("Username already exists.");
        }

        var existingUserByEmail = await _userRepository.GetUserByEmailAsync(user.Email);
        if (existingUserByEmail != null)
        {
            throw new ArgumentException("Email already exists.");
        }

        // Hash the password before saving
        user.PasswordHash = HashPassword(user.PasswordHash); // You need to implement or use a password hashing method

        // Save the user
        var newUser = await _userRepository.AddUserAsync(user);
        return newUser;
    }

    // Example: Method to update user, with some business logic
    public async Task<Users> UpdateUserAsync(Users user)
    {
        // Business logic: Check if the user exists
        var existingUser = await _userRepository.GetUserByIdAsync(user.Id);
        if (existingUser == null)
        {
            throw new NotFoundException($"User with ID {user.Id} not found.");
        }

        // Check if the email or username is changed and if it's unique
        if (existingUser.Email != user.Email)
        {
            var userWithSameEmail = await _userRepository.GetUserByEmailAsync(user.Email);
            if (userWithSameEmail != null && userWithSameEmail.Id != user.Id)
            {
                throw new ArgumentException("Email already exists.");
            }
        }

        if (existingUser.Username != user.Username)
        {
            var userWithSameUsername = await _userRepository.GetUserByUsernameAsync(user.Username);
            if (userWithSameUsername != null && userWithSameUsername.Id != user.Id)
            {
                throw new ArgumentException("Username already exists.");
            }
        }

        // Update the user
        var updatedUser = await _userRepository.UpdateUserAsync(user);
        return updatedUser;
    }

    // Example: Method to delete a user, with some business logic
    public async Task<bool> DeleteUserAsync(long id)
    {
        // Business logic: Check if the user exists before deletion
        var existingUser = await _userRepository.GetUserByIdAsync(id);
        if (existingUser == null)
        {
            throw new NotFoundException($"User with ID {id} not found.");
        }

        // Additional business logic might go here, like checking if the user has any active projects or tasks

        return await _userRepository.DeleteUserAsync(id);
    }

    // Helper method for password hashing
    private string HashPassword(string password)
    {
        // Implement your password hashing logic here
        // For example, using BCrypt:
        // return BCrypt.Net.BCrypt.HashPassword(password);
        return password; // Placeholder, replace with actual hashing
    }
}
}