using TaskFlow.Server.Models;


namespace TaskFlow.Server.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(long id);
        Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(long projectId);
        Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(long userId);
        Task<Tasks> CreateTaskAsync(Tasks task);
        Task<Tasks> UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(long id);
    }
}