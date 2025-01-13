using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Models;
using TaskFlow.Server.Services;
using TaskFlow.Server.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace TaskFlow.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _tasksService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(long id)
        {
            try
            {
                var task = await _tasksService.GetTaskByIdAsync(id);
                return Ok(task);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetTasksByProjectId(long projectId)
        {
            try
            {
                var tasks = await _tasksService.GetTasksByProjectIdAsync(projectId);
                return Ok(tasks);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTasksByUserId(long userId)
        {
            try
            {
                var tasks = await _tasksService.GetTasksByUserIdAsync(userId);
                return Ok(tasks);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Tasks task)
        {
            try
            {
                var createdTask = await _tasksService.CreateTaskAsync(task);
                return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(long id, [FromBody] Tasks task)
        {
            if (id != task.Id)
                return BadRequest();

            try
            {
                var updatedTask = await _tasksService.UpdateTaskAsync(task);
                return Ok(updatedTask);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
            try
            {
                var deleted = await _tasksService.DeleteTaskAsync(id);
                if (deleted)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}