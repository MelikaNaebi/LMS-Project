using LMS.Models;
using LMS.Repositores;
using System;
using System.Threading.Tasks;

namespace LMS.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;

        ICourseRepository Courses { get; }
        IEnrollmentRepository Enrollments { get; }
        IMessageRepository Messages { get; }

        IAssignmentRepository Assignment { get; }

        ISubmissionRepository Submissions { get; }

        IGenericRepository<User> Users { get; }

        Task<int> CompleteAsync();
    }

}
