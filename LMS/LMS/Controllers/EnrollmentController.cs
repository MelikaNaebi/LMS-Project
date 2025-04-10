using LMS.Interfaces;
using LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("enroll")]
        public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
        {
            try
            {
                var result = await _enrollmentService.EnrollStudentAsync(studentId, courseId);
                return Ok(new { success = result, message = "Student enrolled successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("is-enrolled")]
        public async Task<IActionResult> IsStudentEnrolled(int studentId, int courseId)
        {
            var result = await _enrollmentService.IsStudentEnrolledAsync(studentId, courseId);
            return Ok(new { isEnrolled = result });
        }

        [Authorize(Roles = "student")]
        [HttpGet("student/{studentId}/courses")]
        public async Task<IActionResult> GetCoursesByStudentId(int studentId)
        {

            var userId = User.FindFirst("UserId")?.Value;  // 👈 گرفتن آیدی از توکن
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "کاربر نامعتبر است" });
            }
            var courses = await _enrollmentService.GetCoursesByStudentIdAsync(studentId);
            return Ok(courses);
        }
        

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetEnrollmentsByCourse(int courseId)
        {
            var enrollments = await _enrollmentService.GetEnrollmentsByCourseIdAsync(courseId);
            return Ok(enrollments);
        }

        [HttpDelete("unenroll")]
        public async Task<IActionResult> UnenrollStudent(int studentId, int courseId)
        {
            try
            {
                var result = await _enrollmentService.UnenrollStudentAsync(studentId, courseId);
                return Ok(new { success = result, message = "Student unenrolled successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
