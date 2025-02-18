using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IGenericService<Course> _genericService;


        public CourseController(ICourseService courseService, IGenericService<Course> genericService)
        {
            _courseService = courseService;
            _genericService = genericService ?? throw new ArgumentNullException(nameof(genericService));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto courseDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(courseDto.Title))
                {
                    return BadRequest(new { error = "عنوان دوره نباید خالی باشد." });
                }

                var createdCourse = await _courseService.AddCourseAsync(courseDto);
                return Ok(new { message = "دوره با موفقیت ایجاد شد.", course = createdCourse });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _genericService.GetByIdAsync(id);
            if (course == null) return NotFound("Course not found");
            return Ok(course);
        }

    

        [HttpGet("instructor/{instructorId}")]
        public async Task<IActionResult> GetCoursesByInstructor(int instructorId)
        {
            var courses = await _courseService.GetCoursesByInstructorIdAsync(instructorId);
            return Ok(courses);
        }
    }
}

