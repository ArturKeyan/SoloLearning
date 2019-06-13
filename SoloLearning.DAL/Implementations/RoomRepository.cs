using Microsoft.EntityFrameworkCore;
using SoloLearning.DAL.Entities;
using SoloLearning.DAL.Intefaces;
using SoloLearning.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(RoomDTO roomDTO)
        {
            var room = new Room
            {
                Name = roomDTO.Name,
                CreatdDate = DateTime.Now
            };

            await context.Rooms.AddAsync(room);
        }

        public async Task Delete(int id)
        {
            Room room = await context.Rooms.FindAsync(id);
            context.Rooms.Remove(room);
        }

        public async Task<IEnumerable<RoomDTO>> Get()
        {
            var rooms = context.Rooms.Select(m => new RoomDTO
            {
                Id = m.Id,
                Name = m.Name,
                Messages = m.Messages.Select(k => new MessageDTO
                {
                    Id = k.Id,
                    Text = k.Text,
                    UserId = k.UserId
                })
            });

            return await rooms.ToListAsync();
        }

        public async Task<RoomDTO> Get(int id)
        {
            var room = await context.Rooms.Include(m => m.Messages).ThenInclude(m => m.User).FirstOrDefaultAsync(m => m.Id == id);

            if (room == null)
                return null;

            var roomDTO = new RoomDTO
            {
                Id = room.Id,
                Name = room.Name,
                Messages = room.Messages.Select(k => new MessageDTO
                {
                    Id = k.Id,
                    Text = k.Text,
                    UserId = k.UserId
                })
            };

            return roomDTO;
        }
    }
}
