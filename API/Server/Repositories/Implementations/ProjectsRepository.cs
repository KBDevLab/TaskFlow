using TaskFlow.Server.Models;
using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Server.Repositories.Implementations
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly TaskFlowDbContext _context;

        public ProjectsRepository(TaskFlowDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Projects>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.Owner)
                .ToListAsync();
        }

        public async Task<Projects> GetProjectByIdAsync(long id)
        {
            return await _context.Projects
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projects> GetProjectByNameAsync(string name)
        {
            return await _context.Projects
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Projects> AddProjectAsync(Projects project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Projects> UpdateProjectAsync(Projects project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteProjectAsync(long id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}