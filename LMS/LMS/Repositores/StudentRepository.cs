using LMS.Data;
using LMS.Models;

namespace LMS.Repositores
{
    public class StudentRepository : GenericRepository<Student>
    {
        protected readonly DataContext _context;

        public StudentRepository(DataContext context) : base(context)
        {
        }
    }
}