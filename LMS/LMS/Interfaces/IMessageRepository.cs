using LMS.Models;

namespace LMS.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesForUserAsync(int userId);
        Task SendMessageAsync(Message message);
        Task MarkMessagesAsReadAsync(int userId);
    }
}
