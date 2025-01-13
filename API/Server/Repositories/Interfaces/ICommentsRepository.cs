using TaskFlow.Server.Models;


namespace TaskFlow.Server.Repositories.Interfaces
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comments>> GetCommentsByTaskIdAsync(long taskId);
        Task<Comments> GetCommentByIdAsync(long id);
        Task<Comments> AddCommentAsync(Comments comment);
        Task<Comments> UpdateCommentAsync(Comments comment);
        Task<bool> DeleteCommentAsync(long id);
    }
}