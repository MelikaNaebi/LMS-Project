﻿namespace LMS.Dto
{
    public class MessageDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public string Content { get; set; }
        public bool IsRead { get; set; }

    }
}
