using SoloLearning.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoloLearning.DAL.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationContext context;

        public ChatRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
