using TaskFlow.Server.Models;
using TaskFlow.Server.Data;
using TaskFlow.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Server.Repositories.Implementations
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly TaskFlowDbContext _ctx;

        public CommentsRepository(TaskFlowDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Comments>> GetCommentsByTaskIdAsync(long taskId)
        {
            return await _ctx.Comments.Where(c => c.TaskId == taskId).ToListAsync();
        }

        public async Task<Comments> GetCommentByIdAsync(long id)
        {
            return await _ctx.Comments.FindAsync(id);
        }

        public async Task<Comments> AddCommentAsync(Comments comment)
        {
            _ctx.Comments.Add(comment);
            await _ctx.SaveChangesAsync();
            return comment;
        }

        public async Task<Comments> UpdateCommentAsync(Comments comment)
        {
            _ctx.Entry(comment).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> DeleteCommentAsync(long id)
        {
            var comment = await _ctx.Comments.FindAsync(id);
            if (comment == null)
                return false;

            _ctx.Comments.Remove(comment);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}