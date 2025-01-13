using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Repositories.Implementations;
using TaskFlow.Server.Data;


namespace TaskFlow.Server.UnitOfWork
{

public class UnitOfWork : IUnitOfWork
{
    private readonly TaskFlowDbContext _ctx;
    private readonly ILogger _logger;

    private IUsersRepository _userRepository;
    // private IProjectRepository _projectRepository;
    // private ITaskRepository _taskRepository;
    // private ICommentRepository _commentRepository;

    public UnitOfWork(TaskFlowDbContext ctx, ILogger<UnitOfWork> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }

    public IUsersRepository Users
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UsersRepository(_ctx);
            }
            return _userRepository;
        }
    }

    // public IProjectRepository Projects
    // {
    //     get
    //     {
    //         if (_projectRepository == null)
    //         {
    //             _projectRepository = new ProjectRepository(_ctx);
    //         }
    //         return _projectRepository;
    //     }
    // }

    // public ITaskRepository Tasks
    // {
    //     get
    //     {
    //         if (_taskRepository == null)
    //         {
    //             _taskRepository = new TaskRepository(_ctx);
    //         }
    //         return _taskRepository;
    //     }
    // }

    // public ICommentRepository Comments
    // {
    //     get
    //     {
    //         if (_commentRepository == null)
    //         {
    //             _commentRepository = new CommentRepository(_ctx);
    //         }
    //         return _commentRepository;
    //     }
    // }

    public async Task<int> CompleteAsync()
    {
        try
        {
            return await _ctx.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while saving changes to the database.");
            throw;
        }
    }

    public void Dispose()
    {
        _ctx.Dispose();
    }
}

}