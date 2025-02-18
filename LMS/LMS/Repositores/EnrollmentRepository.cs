using LMS.Data;
using LMS.Interfaces;
using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositores
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        protected readonly DataContext _context;

        public EnrollmentRepository(DataContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(int studentId)
        {
            return await _context.Enrollments.Where(e => e.StudentId == studentId).Select(e => e.Course).ToListAsync();


        }

        public async Task<Enrollment> GetEnrollmentByStudentAndCourse(int studentId, int courseId)
        {
            return await _context.Enrollments.Where(e => e.StudentId == studentId && e.CourseId == courseId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseId(int courseId)
        {
            return await _context.Enrollments.Where(e => e.CourseId == courseId).ToListAsync();
        }

    

        public async Task<bool> IsStudentEnrolled(int studentId, int courseId)
        {
            return await _context.Enrollments.AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }
    }
}
