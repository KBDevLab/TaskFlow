using TaskFlow.Server.Models;
using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Exceptions;

namespace TaskFlow.Server.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _taskRepository;

        public TasksService(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(long id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                throw new NotFoundException($"Task with ID {id} not found.");
            }
            return task;
        }

        public async Task<IEnumerable<Tasks>> GetTasksByProjectIdAsync(long projectId)
        {
            var tasks = await _taskRepository.GetTasksByProjectIdAsync(projectId);
            if (!tasks.Any())
            {
                throw new NotFoundException($"No tasks found for project with ID {projectId}.");
            }
            return tasks;
        }

        public async Task<IEnumerable<Tasks>> GetTasksByUserIdAsync(long userId)
        {
            var tasks = await _taskRepository.GetTasksByUserIdAsync(userId);
            if (!tasks.Any())
            {
                throw new NotFoundException($"No tasks found assigned to user with ID {userId}.");
            }
            return tasks;
        }

        public async Task<Tasks> CreateTaskAsync(Tasks task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                throw new ArgumentException("Task title is required.");
            }

            var newTask = await _taskRepository.AddTaskAsync(task);
            return newTask;
        }

        public async Task<Tasks> UpdateTaskAsync(Tasks task)
        {

            var existingTask = await _taskRepository.GetTaskByIdAsync(task.Id);
            if (existingTask == null)
            {
                throw new NotFoundException($"Task with ID {task.Id} not found.");
            }

            var updatedTask = await _taskRepository.UpdateTaskAsync(task);
            return updatedTask;
        }

        public async Task<bool> DeleteTaskAsync(long id)
        {

            var existingTask = await _taskRepository.GetTaskByIdAsync(id);
            if (existingTask == null)
            {
                throw new NotFoundException($"Task with ID {id} not found.");
            }

            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}