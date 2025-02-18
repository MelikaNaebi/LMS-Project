using LMS.Data;
using LMS.Interfaces;
using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositores
{
    public class SubmissionRepository : GenericRepository<Submission>, ISubmissionRepository
    {

        protected readonly DataContext _context;

        public SubmissionRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Submission>> GetAllSubmissionsByAssignmentAsync(int assignmentId)
        {
            return await _context.Submissions.Where(s => s.AssignmentId == assignmentId).ToListAsync();
        }
    }
}
