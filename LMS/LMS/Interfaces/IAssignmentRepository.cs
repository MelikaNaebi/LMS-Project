using LMS.Models;

namespace LMS.Interfaces
{
    public interface IAssignmentRepository
    {
       Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(int courseId);


    }
}
