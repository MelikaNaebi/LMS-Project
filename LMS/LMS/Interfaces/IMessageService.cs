using LMS.Dto;
using LMS.Models;


namespace LMS.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessagesForUserAsync(int userId);


        Task MarkMessagesAsReadAsync(int userId);
        Task SendMessageAsync(MessageDto messageDto);
    }
}
