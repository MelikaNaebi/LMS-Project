using LMS.Interfaces;
using LMS.Models;
using LMS.Repositores;

namespace LMS.Services
{
    public class EnrollmentService : GenericService<Enrollment>, IEnrollmentService

    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        }
        public async Task<bool> EnrollStudentAsync(int studentId, int courseId)
        {
            var firstcheck=await _unitOfWork.Enrollments.GetEnrollmentByStudentAndCourse(studentId, courseId);
            if (firstcheck != null) {
                throw new KeyNotFoundException("already registerd");
            }
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.UtcNow  
            };
            await _unitOfWork.Repository<Enrollment>().AddAsync(enrollment);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<Enrollment> GetEnrollmentByStudentAndCourseAsync(int studentId, int courseId)
        {
            return await _unitOfWork.Enrollments.GetEnrollmentByStudentAndCourse(studentId, courseId);    
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
          return await _unitOfWork.Enrollments.GetEnrollmentsByCourseId( courseId);
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentIdAsync(int studentId)
        {
            return await _unitOfWork.Enrollments.GetCoursesByStudentIdAsync(studentId);
        }
        public async  Task<bool> IsStudentEnrolledAsync(int studentId, int courseId)
        {
            return await _unitOfWork.Enrollments.GetEnrollmentByStudentAndCourse(studentId, courseId) != null;
        }

        public async Task<bool> UnenrollStudentAsync(int studentId, int courseId)
        {
            var existingEnrollment = await _unitOfWork.Enrollments.GetEnrollmentByStudentAndCourse(studentId, courseId);
            if (existingEnrollment == null)
            {
                throw new KeyNotFoundException("Not found");
            }

            await _unitOfWork.Repository<Enrollment>().DeleteByEntityAsync(existingEnrollment);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
