using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Enrollment
    {
        
        public DateTime EnrollmentDate { get; set; }

        public double? Grade { get; set; }

      
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
      
    }
}
