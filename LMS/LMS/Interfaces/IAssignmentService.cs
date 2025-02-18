using LMS.Dto;
using LMS.Models;

namespace LMS.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(int courseId);

        Task AddAssignmentAsync(AssignmentDto assignmentDto, int InstructorId);

        
    }
}
