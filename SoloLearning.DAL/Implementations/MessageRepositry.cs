using SoloLearning.DAL.Entities;
using SoloLearning.DAL.Intefaces;
using SoloLearning.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.DAL.Implementations
{
    public class MessageRepositry : IMessageRepository
    {
        private readonly ApplicationContext context;

        public MessageRepositry(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task Add(MessageDTO messageDTO)
        {
            var message = new Message
            {
                Text = messageDTO.Text,
                RoomId = messageDTO.RoomId,
                UserId = messageDTO.User.Id,
                CreatedDate = DateTime.Now
            };

            await context.Messages.AddAsync(message);
        }

        public async Task Delete(int id)
        {
            Message message = await context.Messages.FindAsync(id);
            context.Messages.Remove(message);
        }
    }
}
