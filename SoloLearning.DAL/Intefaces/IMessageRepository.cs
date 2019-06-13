using SoloLearning.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.DAL.Intefaces
{
    public interface IMessageRepository
    {
        Task Add(MessageDTO messageDTO);
        Task Delete(int id);
    }
}
