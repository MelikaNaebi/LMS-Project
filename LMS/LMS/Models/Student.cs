using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Student :User
    {
      
      
        public int studentId { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new();

        public List<Submission> Submissions { get; set; } = new();


    }
}
