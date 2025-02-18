using LMS.Models;

namespace LMS.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<Submission>> GetAllSubmissionsByAssignmentAsync( int assignmentId);
    }
}
