using SoloLearning.DAL.Entities;
using SoloLearning.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.DAL.Implementations
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationContext context;

        public RoomRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Task<bool> Add(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
