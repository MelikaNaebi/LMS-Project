using LMS.Data;
using LMS.Interfaces;
using LMS.Models;
using LMS.Repositores;
using System;
using System.Threading.Tasks;

namespace LMS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        //private readonly GenericRepository<T> _genericRepository;
        private readonly Dictionary<Type, object> _repositories = new(); // اینجا تعریف شده است
        public ICourseRepository Courses { get; }
        public IEnrollmentRepository Enrollments { get; }
        public IMessageRepository Messages { get; }

        public IAssignmentRepository Assignment {  get; }

        public ISubmissionRepository Submissions {  get; }
        public IGenericRepository<User> Users { get;  set; }


        public UnitOfWork(DataContext context,
                  ICourseRepository courseRepository,
                  IEnrollmentRepository enrollmentRepository, 
                  IMessageRepository messageRepository,
                  ISubmissionRepository submissionRepository,
                  IAssignmentRepository assignment,        
                  IGenericRepository<User> users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Courses = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            Enrollments = enrollmentRepository ?? throw new ArgumentNullException(nameof(enrollmentRepository));
            Messages = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            Submissions = submissionRepository ?? throw new ArgumentNullException(nameof(submissionRepository));
            Assignment = assignment ?? throw new ArgumentNullException(nameof(assignment));
            Users = users;
        }



        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new GenericRepository<T>(_context);
                _repositories[typeof(T)] = repository;
            }

            return (IGenericRepository<T>)_repositories[typeof(T)];
        }
    }


}
