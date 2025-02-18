using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;
using LMS.Repositores;

namespace LMS.Services
{
    public class SubmissionService : GenericService<Submission>, ISubmissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Assignment> _assignmentRepository;


        public SubmissionService(IUnitOfWork unitOfWork, IGenericRepository<Assignment> assignmentRepository) : base(unitOfWork)
        {

            _unitOfWork = unitOfWork;
            _assignmentRepository = assignmentRepository ?? throw new ArgumentNullException(nameof(assignmentRepository));
        }

        public async Task AddAsubmissionAsync(SubmissionDto submissionDto, int assignmentId)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(assignmentId);
            if (assignment == null)
            {
                throw new Exception("تکلیف مورد نظر یافت نشد.");
            }

            var submission = new Submission
            {
                SubmissionDate = DateTime.Now,  
                StudentId = submissionDto.StudentId, 
                AssignmentId = assignmentId  ,
                Content = submissionDto.Content
            };


            await _unitOfWork.Repository<Submission>().AddAsync(submission);
            await _unitOfWork.CompleteAsync();

        }

        public async Task<IEnumerable<Submission>> GetAllSubmissionsByAssignmentAsync(int assignmentId)
        {
         

            return await _unitOfWork.Submissions.GetAllSubmissionsByAssignmentAsync(assignmentId);
        }
    }
}
