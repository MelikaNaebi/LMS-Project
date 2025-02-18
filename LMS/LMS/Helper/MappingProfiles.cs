using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using LMS.Models;
using LMS.Dto;
namespace LMS.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Assignment, AssignmentDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Submission, SubmissionDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
