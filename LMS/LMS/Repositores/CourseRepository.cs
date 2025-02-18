using LMS.Data;
using LMS.Interfaces;
using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositores
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        protected readonly DataContext _context;

        public CourseRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorAsync(int InstructorId)
        {
            return await _context.Courses.Where(c =>c.InstructorId == InstructorId).ToListAsync();
        }

       
    }
}
