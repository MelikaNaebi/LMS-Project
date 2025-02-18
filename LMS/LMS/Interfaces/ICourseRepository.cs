using LMS.Models;


namespace LMS.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int InstructorId);

    }
}
