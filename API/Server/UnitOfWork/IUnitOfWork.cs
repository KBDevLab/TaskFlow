using TaskFlow.Server.Models;
using TaskFlow.Server.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUsersRepository Users { get; }
    // IProjectRepository Projects { get; }
    // ITaskRepository Tasks { get; }
    // ICommentRepository Comments { get; }
    
    Task<int> CompleteAsync();
}