using System.Collections.Generic;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public interface IProjectsService
    {
        Task<IEnumerable<Projects>> GetAllProjectsAsync();
        Task<Projects> GetProjectByIdAsync(long id);
        Task<Projects> AddProjectAsync(Projects project);
        Task<Projects> UpdateProjectAsync(Projects project);
        Task<bool> DeleteProjectAsync(long id);
    }
}