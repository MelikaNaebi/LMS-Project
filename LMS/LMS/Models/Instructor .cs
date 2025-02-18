using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Instructor :User
    {
      
        public int InstructorCode { get; set; }
        public string Department { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}
