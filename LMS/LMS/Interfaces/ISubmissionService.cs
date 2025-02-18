using LMS.Dto;
using LMS.Models;

namespace LMS.Interfaces
{
    public interface ISubmissionService
    {
        Task<IEnumerable<Submission>> GetAllSubmissionsByAssignmentAsync(int assignmentId);
        Task AddAsubmissionAsync(SubmissionDto submissionDto, int assignmentId);

    }
}
