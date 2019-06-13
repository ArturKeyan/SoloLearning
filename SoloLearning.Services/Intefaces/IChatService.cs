using SoloLearning.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.Services.Intefaces
{
    public interface IChatService
    {
        Task SendMessage(MessageDTO messageDTO);
        Task CreateRoom(RoomDTO roomDTO);
        Task<RoomDTO> GetRoom(int roomId);
        Task<IEnumerable<RoomDTO>> GetAllRooms();
        Task RemoveRoom(int roomId);

    }
}
    