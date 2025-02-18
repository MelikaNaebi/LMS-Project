namespace LMS.Models
{
    public class Assignment
    {

        public int Id { get; set; }  
        public string Title { get; set; }  
        public string Description { get; set; }  
        public int CourseId { get; set; }  
        public Course Course { get; set; }

        public DateTime DueDate { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

      

        public List<Submission> Submissions { get; set; } = new();
    }
}
