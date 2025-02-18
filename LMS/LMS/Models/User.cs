using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }

        public List<Message> SentMessages { get; set; } = new();
        public List<Message> ReceivedMessages { get; set; } = new();


    }
}
