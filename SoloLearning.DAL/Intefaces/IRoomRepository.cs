using SoloLearning.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.DAL.Intefaces
{
    public interface IRoomRepository
    {
        Task<bool> Add(Room room);
    }
}
