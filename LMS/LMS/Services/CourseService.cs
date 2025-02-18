using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;

namespace LMS.Services
{
    public class CourseService : GenericService<Course>, ICourseService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnrollmentService _enrollmentService;
        public CourseService(IUnitOfWork unitOfWork, IEnrollmentService enrollmentService) : base(unitOfWork)
        {
            _enrollmentService = enrollmentService;
            _unitOfWork = unitOfWork;

        }

        public async Task<Course> AddCourseAsync(CourseDto courseDto)
        {
            var instructor = await _unitOfWork.Repository<Instructor>().GetByIdAsync(courseDto.InstructorId);
            if (instructor == null)
            {
                throw new Exception("استاد مورد نظر یافت نشد.");
            }

            var Course = new Course { 
            Title=courseDto.Title,
            InstructorId=courseDto.InstructorId,      
            };
            await _unitOfWork.Repository<Course>().AddAsync(Course);
            await _unitOfWork.CompleteAsync();
            return Course;
        }

        public async Task<IEnumerable<Course>> GetCoursesByInstructorIdAsync(int instructorId)
        {
            return   await _unitOfWork.Courses.GetCoursesByInstructorAsync(instructorId);
           

        }

        public async Task<bool> IsStudentEnrolledAsync(int studentId, int courseId)
        {
            return await _enrollmentService.IsStudentEnrolledAsync(studentId, courseId);
        }
    }
}
