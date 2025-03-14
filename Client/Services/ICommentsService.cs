using System.Collections.Generic;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public interface ICommentsService
    {
        Task<IEnumerable<Comments>> GetCommentsByTaskIdAsync(long taskId);
        Task<Comments> GetCommentByIdAsync(long id);
        Task<Comments> AddCommentAsync(Comments comment);
        Task<Comments> UpdateCommentAsync(Comments comment);
        Task<bool> DeleteCommentAsync(long id);
    }
}