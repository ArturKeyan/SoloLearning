using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoloLearning.Web.Models
{
    public class UserCreateModel : UserModel
    {
        public string Password { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
