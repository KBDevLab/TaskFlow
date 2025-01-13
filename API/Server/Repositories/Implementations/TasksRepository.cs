using TaskFlow.Server.Models;
using TaskFlow.Server.Data;
using TaskFlow.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Server.Repositories.Implementations
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TaskFlowDbContext _context;

        public TasksRepository(TaskFlowDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .ToListAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(long id)
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(long projectId)
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(long userId)
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .Where(t => t.AssignedTo == userId)
                .ToListAsync();
        }

        public async Task<Tasks> AddTaskAsync(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Tasks> UpdateTaskAsync(Tasks task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(long id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}