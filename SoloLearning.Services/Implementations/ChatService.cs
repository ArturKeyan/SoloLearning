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

        public async Task CreateRoom(RoomDTO roomDTO)
        {
            await unitOfWork.RoomRepository.Add(roomDTO);
            await unitOfWork.SaveAsync();

        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            return await unitOfWork.RoomRepository.Get();
        }

        public async Task<RoomDTO> GetRoom(int roomId)
        {
            return await unitOfWork.RoomRepository.Get(roomId);
        }

        public async Task RemoveRoom(int roomId)
        {
            await unitOfWork.RoomRepository.Delete(roomId);
            await unitOfWork.SaveAsync();
        }

        public Task SendMessage(MessageDTO messageDTO)
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
