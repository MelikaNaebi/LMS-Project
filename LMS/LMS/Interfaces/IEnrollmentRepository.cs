using LMS.Models;

namespace LMS.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(int studentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int courseId);
        Task<Enrollment> GetEnrollmentByStudentAndCourse(int studentId, int courseId);
        Task<bool> IsStudentEnrolled(int studentId, int courseId);
    }
}
