using System.Collections.Generic;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(long id);
        Task<Tasks> AddTaskAsync(Tasks task);
        Task<Tasks> UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(long id);
    }
}