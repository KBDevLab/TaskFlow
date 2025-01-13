using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace TaskFlow.Server.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _userRepository;

    public UsersController(IUsersRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] Users user)
    {
        if (user == null)
            return BadRequest();

        var addedUser = await _userRepository.AddUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = addedUser.Id }, addedUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(long id, [FromBody] Users user)
    {
        if (id != user.Id)
            return BadRequest();

        var existingUser = await _userRepository.GetUserByIdAsync(id);
        if (existingUser == null)
            return NotFound();

        var updatedUser = await _userRepository.UpdateUserAsync(user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var deleted = await _userRepository.DeleteUserAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}

}