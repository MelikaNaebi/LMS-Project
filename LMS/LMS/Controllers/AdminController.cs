using Microsoft.AspNetCore.Mvc;
using LMS.Interfaces;
using LMS.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;
using LMS.Dto;

namespace LMS.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _adminService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _adminService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("users")]
        public async Task<ActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _adminService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
        }

        [HttpPut("users/{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _adminService.UpdateUserAsync(id, userDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleted = await _adminService.DeleteUserAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
