using TaskFlow.Server.Models;


namespace TaskFlow.Server.Services
{

    public interface IProjectsService
    {
        Task<IEnumerable<Projects>> GetAllProjectsAsync();
        Task<Projects> GetProjectByIdAsync(long id);
        Task<Projects> CreateProjectAsync(Projects project);
        Task<Projects> UpdateProjectAsync(Projects project);
        Task<bool> DeleteProjectAsync(long id);
    }
}