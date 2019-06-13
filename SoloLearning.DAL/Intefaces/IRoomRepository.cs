using SoloLearning.DAL.Entities;
using SoloLearning.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.DAL.Intefaces
{
    public interface IRoomRepository
    {
        Task Add(RoomDTO roomDTO);
        Task<IEnumerable<RoomDTO>> Get();
        Task<RoomDTO> Get(int id);
        Task Delete(int id);
    }
}
