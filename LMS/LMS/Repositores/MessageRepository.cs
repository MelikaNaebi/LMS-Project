using LMS.Data;
using LMS.Interfaces;
using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repositores
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        protected readonly DataContext _context;

        public MessageRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Message>> GetMessagesForUserAsync(int userId)
        {
            return await _context.Messages.Where(m => m.SenderId == userId || m.ReceiverId == userId).OrderByDescending(m => m.SentAt).ToListAsync();
        }

        public async Task MarkMessagesAsReadAsync(int userId)
        {



         var unreadMessages = await _context.Messages.Where(m => m.ReceiverId == userId && !m.IsRead).ToListAsync();



            if (unreadMessages.Any())
            {
                foreach (var message in unreadMessages)
                {
                    message.IsRead = true;
                }

                await _context.SaveChangesAsync();    
            }
        }

        public async Task SendMessageAsync(Message message)
        {
            message.SentAt = DateTime.UtcNow;   
            message.IsRead = false; 

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
