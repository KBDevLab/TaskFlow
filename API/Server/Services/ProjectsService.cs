using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Models;
using TaskFlow.Server.Exceptions;


namespace TaskFlow.Server.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectRepository;
        private readonly IUsersRepository _userRepository;

        public ProjectsService(IProjectsRepository projectRepository, IUsersRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Projects>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }

        public async Task<Projects> GetProjectByIdAsync(long id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                throw new NotFoundException($"Projects with ID {id} not found.");
            }
            return project;
        }

        public async Task<Projects> CreateProjectAsync(Projects project)
        {
            
            if (string.IsNullOrWhiteSpace(project.Name))
            {
                throw new ArgumentException("Projects name is required.");
            }

            var existingProject = await _projectRepository.GetProjectByNameAsync(project.Name);
            if (existingProject != null)
            {
                throw new ArgumentException("Projects name already exists.");
            }

            var owner = await _userRepository.GetUserByIdAsync(project.OwnerId);
            if (owner == null)
            {
                throw new ArgumentException("Owner does not exist.");
            }

            var newProject = await _projectRepository.AddProjectAsync(project);
            return newProject;
        }

        public async Task<Projects> UpdateProjectAsync(Projects project)
        {
            var existingProject = await _projectRepository.GetProjectByIdAsync(project.Id);
            if (existingProject == null)
            {
                throw new NotFoundException($"Projects with ID {project.Id} not found.");
            }

            if (existingProject.Name != project.Name)
            {
                var projectWithSameName = await _projectRepository.GetProjectByNameAsync(project.Name);
                if (projectWithSameName != null && projectWithSameName.Id != project.Id)
                {
                    throw new ArgumentException("Projects name already exists.");
                }
            }

            var owner = await _userRepository.GetUserByIdAsync(project.OwnerId);
            if (owner == null)
            {
                throw new ArgumentException("Owner does not exist.");
            }

            var updatedProject = await _projectRepository.UpdateProjectAsync(project);
            return updatedProject;
        }

        public async Task<bool> DeleteProjectAsync(long id)
        {
            var existingProject = await _projectRepository.GetProjectByIdAsync(id);
            if (existingProject == null)
            {
                throw new NotFoundException($"Projects with ID {id} not found.");
            }

            return await _projectRepository.DeleteProjectAsync(id);
        }
    }
}