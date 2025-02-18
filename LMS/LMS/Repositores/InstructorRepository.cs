using LMS.Data;
using LMS.Models;

namespace LMS.Repositores
{
    public class InstructorRepository : GenericRepository<Instructor>
    {
        protected readonly DataContext _context;

        public InstructorRepository(DataContext context) : base(context)
        {
        }
    }
}
