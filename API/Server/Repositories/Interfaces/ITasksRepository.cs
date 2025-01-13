using TaskFlow.Server.Models;


namespace TaskFlow.Server.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(long id);
        Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(long projectId);
        Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(long userId);
        Task<Tasks> AddTaskAsync(Tasks task);
        Task<Tasks> UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(long id);
    }
}