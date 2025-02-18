using LMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LMS.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(int studentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId);
        Task<Enrollment> GetEnrollmentByStudentAndCourseAsync(int studentId, int courseId);
        Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);
        Task<bool> EnrollStudentAsync(int studentId, int courseId);
        Task<bool> UnenrollStudentAsync(int studentId, int courseId);

    }
}
