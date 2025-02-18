namespace LMS.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new();

        public List<Assignment> Assignments { get; set; } = new();

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }
    }    

    }
