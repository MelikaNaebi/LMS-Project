using LMS.Data;
using LMS.Interfaces;
using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositores
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {

        protected readonly DataContext _context;
        

        public  AssignmentRepository(DataContext context) : base(context) { }


        public async Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(int courseId)
        {
            return await _context.Assignments.Where(a => a.CourseId == courseId).ToListAsync();
        }

      
    }
}
