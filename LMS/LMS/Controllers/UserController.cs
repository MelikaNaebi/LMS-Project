using LMS.Repositores;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }
}
