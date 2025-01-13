using TaskFlow.Server.Models;


namespace TaskFlow.Server.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(long id);
        Task<Users> GetUserByUsernameAsync(string username);
        Task<Users> GetUserByEmailAsync(string email);
        Task<Users> AddUserAsync(Users user);
        Task<Users> UpdateUserAsync(Users user);
        Task<bool> DeleteUserAsync(long id);
    }
}