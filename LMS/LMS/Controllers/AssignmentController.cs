using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
     

            [HttpPost]
            public async Task<IActionResult> CreateAssignment([FromBody] AssignmentDto assignmentDto, [FromQuery] int InstructorId)
            {
                try
                {
                    await _assignmentService.AddAssignmentAsync(assignmentDto, InstructorId);
                    return Ok(new { message = "تکلیف با موفقیت ایجاد شد." });
                }
                catch (UnauthorizedAccessException ex)
                {
                    return Forbid(ex.Message);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        

      

         [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetAssignmentsByCourse(int courseId)
        {
            var assignments = await _assignmentService.GetAssignmentsByCourseAsync(courseId);
            return Ok(assignments);
        }

      
    }
}
