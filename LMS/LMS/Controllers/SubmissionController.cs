using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : Controller
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService=submissionService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubmission([FromBody] SubmissionDto submissionDto, [FromQuery] int assignmentId)
        {
            try
            {
             
                await _submissionService.AddAsubmissionAsync(submissionDto, assignmentId);
                return Ok(new { message = "تکلیف با موفقیت ارسال شد." });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new { error = errorMessage });
            }
        }

        [HttpGet("submission/{assignmentId}")]
        public async Task<IActionResult> GetAllSubmissionsByAssignmentAsync(int assignmentId)
        {
            var submissions = await _submissionService.GetAllSubmissionsByAssignmentAsync(assignmentId);

            return Ok(submissions);

        }
    }
}
