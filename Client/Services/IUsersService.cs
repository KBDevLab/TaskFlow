using System.Collections.Generic;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(long id);
        Task<Users> AddUserAsync(Users user);
        Task<Users> UpdateUserAsync(Users user);
        Task<bool> DeleteUserAsync(long id);
    }
}