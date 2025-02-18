using LMS.Repositores;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly InstructorRepository _instructorRepository;
    public InstructorController(InstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetInstructorById(int id)
    //{
    //    var instructor = await _instructorRepository.GetByIdAsync(id);
    //    if (instructor == null) return NotFound();
    //    return Ok(instructor);
    //}
}