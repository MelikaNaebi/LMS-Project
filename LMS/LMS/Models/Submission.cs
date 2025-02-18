namespace LMS.Models
{
    public class Submission
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int StudentId { get; set; }  

        public Student Student { get; set; }
        public int AssignmentId { get; set; }  

        public Assignment Assignment { get; set; }
    }
}
