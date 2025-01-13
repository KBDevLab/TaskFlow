using TaskFlow.Server.Models;
using TaskFlow.Server.Data;
using TaskFlow.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Server.Repositories.Implementations
{
public class UsersRepository : IUsersRepository
{
    private readonly TaskFlowDbContext _ctx;

    public UsersRepository(TaskFlowDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Users>> GetAllUsersAsync()
    {
        return await _ctx.Users.ToListAsync();
    }

    public async Task<Users> GetUserByIdAsync(long id)
    {
        return await _ctx.Users.FindAsync(id);
    }

    public async Task<Users> GetUserByUsernameAsync(string username)
    {
        return await _ctx.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<Users> GetUserByEmailAsync(string email)
    {
        return await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Users> AddUserAsync(Users user)
    {
        _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task<Users> UpdateUserAsync(Users user)
    {
        _ctx.Entry(user).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        var user = await _ctx.Users.FindAsync(id);
        if (user == null)
            return false;

        _ctx.Users.Remove(user);
        await _ctx.SaveChangesAsync();
        return true;
    }
}
}