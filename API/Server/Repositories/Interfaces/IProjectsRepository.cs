using TaskFlow.Server.Models;


namespace TaskFlow.Server.Repositories.Interfaces
{


    public interface IProjectsRepository
    {
        Task<IEnumerable<Projects>> GetAllProjectsAsync();
        Task<Projects> GetProjectByIdAsync(long id);
        Task<Projects> GetProjectByNameAsync(string name);
        Task<Projects> AddProjectAsync(Projects project);
        Task<Projects> UpdateProjectAsync(Projects project);
        Task<bool> DeleteProjectAsync(long id);
    }
}