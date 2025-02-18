using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;

namespace LMS.Services
{
    public class MessageService : GenericService<Message>, IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  Task<IEnumerable<Message>> GetMessagesForUserAsync(int userId)
        {
            return _unitOfWork.Messages.GetMessagesForUserAsync(userId);
        }

        public Task MarkMessagesAsReadAsync(int userId)
        {
            return _unitOfWork.Messages.MarkMessagesAsReadAsync(userId);
        }

        public async Task SendMessageAsync(MessageDto messageDto)
        {
            var sender = await _unitOfWork.Users.GetByIdAsync(messageDto.SenderId);
            var receiver = await _unitOfWork.Users.GetByIdAsync(messageDto.ReceiverId);

            if (sender == null || receiver == null)
            {
                throw new ArgumentException("فرستنده یا گیرنده یافت نشد.");
            }


            var message = new Message
            {
                SenderId = messageDto.SenderId,
                ReceiverId = messageDto.ReceiverId,
                Content = messageDto.Content,
                SentAt = DateTime.UtcNow,
                IsRead = false
            };


            await _unitOfWork.Repository<Message>().AddAsync(message);
            await _unitOfWork.CompleteAsync();
        }
    }
}

