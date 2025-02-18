
using LMS.Dto;
using LMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace LMS.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCoursesByInstructorIdAsync(int instructorId);
        Task<Course> AddCourseAsync(CourseDto courseDto);
        Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);
    }
}
