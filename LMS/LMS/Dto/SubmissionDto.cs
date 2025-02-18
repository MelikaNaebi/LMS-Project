namespace LMS.Dto
{
    public class SubmissionDto
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }

        public int StudentId {  get; set; }
        public string Content { get; set; }

    }
}
