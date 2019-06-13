using SoloLearning.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.Services.Intefaces
{
    public interface IChatService
    {
        Task<bool> SendMessage(MessageDTO messageDTO);
        Task<bool> CreateRoom(RoomDTO roomDTO);
        Task<RoomDTO> GetRoom(int roomId);
        Task<IEnumerable<RoomDTO>> GetAllRooms();

    }
}
    