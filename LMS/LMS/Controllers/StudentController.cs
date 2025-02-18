using LMS.Interfaces;
using LMS.Models;
using LMS.Repositores;
using LMS.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IGenericService<Student> _genericService;
    public StudentController(StudentRepository studentRepository)
    {
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetStudentById(int id)
    //{
    //    var student = await _genericService.GetByIdAsync(id);
    //    if (student == null)
    //        return NotFound(new { message = "Student not found" });

    //    return Ok(student);
    //}

   
}