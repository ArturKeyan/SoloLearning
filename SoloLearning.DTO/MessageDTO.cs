using System;
using System.Collections.Generic;
using System.Text;

namespace SoloLearning.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public string Text { get; set; }
        public int RoomId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
