using LMS.Data;
using LMS.Models;

namespace LMS.Repositores
{
    public class UserRepository : GenericRepository<User>
    {
        protected readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}