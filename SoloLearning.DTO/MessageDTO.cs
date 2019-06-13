using System;
using System.Collections.Generic;
using System.Text;

namespace SoloLearning.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public int ChatId { get; set; }
    }
}
