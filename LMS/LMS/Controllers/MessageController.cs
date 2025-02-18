using LMS.Dto;
using LMS.Interfaces;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // دریافت پیام‌های یک کاربر
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesForUser(int userId)
        {
            var messages = await _messageService.GetMessagesForUserAsync(userId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _messageService.SendMessageAsync(messageDto);
            return Ok(new { message = "پیام با موفقیت ارسال شد." });
        }

        // علامت‌گذاری پیام‌های خوانده‌نشده به عنوان خوانده‌شده
        [HttpPost("mark-as-read/{userId}")]
        public async Task<IActionResult> MarkMessagesAsRead(int userId)
        {
            await _messageService.MarkMessagesAsReadAsync(userId);
            return Ok(new { message = "Messages marked as read." });
        }
    }
}
