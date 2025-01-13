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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet("task/{taskId}")]
        public async Task<IActionResult> GetCommentsByTaskId(long taskId)
        {
            var comments = await _commentsService.GetCommentsByTaskIdAsync(taskId);
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(long id)
        {
            try
            {
                var comment = await _commentsService.GetCommentByIdAsync(id);
                return Ok(comment);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] Comments comment)
        {
            if (comment == null)
                return BadRequest();

            try
            {
                var addedComment = await _commentsService.AddCommentAsync(comment);
                return CreatedAtAction(nameof(GetCommentById), new { id = addedComment.Id }, addedComment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(long id, [FromBody] Comments comment)
        {
            if (id != comment.Id)
                return BadRequest();

            try
            {
                var updatedComment = await _commentsService.UpdateCommentAsync(comment);
                return Ok(updatedComment);
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
        public async Task<IActionResult> DeleteComment(long id)
        {
            try
            {
                var deleted = await _commentsService.DeleteCommentAsync(id);
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