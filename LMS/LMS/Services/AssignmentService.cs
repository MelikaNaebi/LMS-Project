using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;
using LMS.Repositores;

namespace LMS.Services
{
    public class AssignmentService : GenericService<Assignment>, IAssignmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IGenericRepository<Course> _assignmentRepository;


        public AssignmentService(IUnitOfWork unitOfWork, IGenericRepository<Course> courseRepository, IGenericRepository<Assignment> assignmentRepository) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        public  async Task AddAssignmentAsync(AssignmentDto assignmentDto, int InstructorId)
        {
            var course = await _courseRepository.GetByIdAsync(assignmentDto.CourseId);
            if (course == null )
            {
                throw new Exception("دوره مورد نظر یافت نشد.");
            }
            var assignment = new Assignment
            {
                CourseId = assignmentDto.CourseId,
                Title = assignmentDto.Title,
                Description = assignmentDto.Description,
                DueDate = assignmentDto.DueDate
            };

            await _unitOfWork.Repository<Assignment>().AddAsync(assignment);
            await _unitOfWork.CompleteAsync();

        }

        public Task<IEnumerable<Assignment>> GetAssignmentsByCourseAsync(int courseId)
        {
            return _unitOfWork.Assignment.GetAssignmentsByCourseAsync(courseId);
        }

    
        
    }
}
