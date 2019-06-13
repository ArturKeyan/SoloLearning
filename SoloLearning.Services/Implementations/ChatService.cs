using SoloLearning.DAL.UnitOfWork;
using SoloLearning.DTO;
using SoloLearning.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork unitOfWork;

        public ChatService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> CreateRoom(RoomDTO roomDTO)
        {
            //string path = await unitOfWork.ChatRepository.Add(designDTO, replaceFirst);
            //return path;
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public Task<RoomDTO> GetRoom(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendMessage(MessageDTO messageDTO)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<RoomDTO>> IChatService.GetAllRooms()
        {
            throw new NotImplementedException();
        }

        Task<RoomDTO> IChatService.GetRoom(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
