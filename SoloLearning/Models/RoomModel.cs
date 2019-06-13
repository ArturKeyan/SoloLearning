using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoloLearning.Web.Models
{

    public class RoomCreateModel
    {
        public string Name { get; set; }
    }

    public class RoomModel : RoomCreateModel
    {
        public int Id { get; set; }
        public UserModel Owner { get; set; }

        public IEnumerable<MessageModel> Messages { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
