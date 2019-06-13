using System;
using System.Collections.Generic;
using System.Text;

namespace SoloLearning.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDTO Owner { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
