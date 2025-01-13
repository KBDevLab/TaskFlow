using TaskFlow.Server.Models;
using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Exceptions;

namespace TaskFlow.Server.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<IEnumerable<Comments>> GetCommentsByTaskIdAsync(long taskId)
        {
            return await _commentsRepository.GetCommentsByTaskIdAsync(taskId);
        }

        public async Task<Comments> GetCommentByIdAsync(long id)
        {
            var comment = await _commentsRepository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                throw new NotFoundException($"Comment with ID {id} not found.");
            }
            return comment;
        }

        public async Task<Comments> AddCommentAsync(Comments comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                throw new ArgumentException("Comment content cannot be empty.");
            }

            comment.CreatedAt = DateTime.UtcNow;

            var newComment = await _commentsRepository.AddCommentAsync(comment);
            return newComment;
        }

        public async Task<Comments> UpdateCommentAsync(Comments comment)
        {
            var existingComment = await _commentsRepository.GetCommentByIdAsync(comment.Id);
            if (existingComment == null)
            {
                throw new NotFoundException($"Comment with ID {comment.Id} not found.");
            }

            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                throw new ArgumentException("Comment content cannot be empty.");
            }

            var updatedComment = await _commentsRepository.UpdateCommentAsync(comment);
            return updatedComment;
        }

        public async Task<bool> DeleteCommentAsync(long id)
        {
            var existingComment = await _commentsRepository.GetCommentByIdAsync(id);
            if (existingComment == null)
            {
                throw new NotFoundException($"Comment with ID {id} not found.");
            }

            return await _commentsRepository.DeleteCommentAsync(id);
        }
    }
}