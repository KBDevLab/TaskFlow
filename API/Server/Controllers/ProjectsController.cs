using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskFlow.Server.Models; 
using TaskFlow.Server.Services;
using TaskFlow.Server.Exceptions;

namespace TaskFlow.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectsService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(long id)
        {
            try
            {
                var project = await _projectsService.GetProjectByIdAsync(id);
                return Ok(project);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Projects project)
        {
            if (project == null)
                return BadRequest();

            try
            {
                var createdProject = await _projectsService.CreateProjectAsync(project);
                return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(long id, [FromBody] Projects project)
        {
            if (id != project.Id)
                return BadRequest();

            try
            {
                var updatedProject = await _projectsService.UpdateProjectAsync(project);
                return Ok(updatedProject);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            try
            {
                var deleted = await _projectsService.DeleteProjectAsync(id);
                if (!deleted)
                    return NotFound();
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}