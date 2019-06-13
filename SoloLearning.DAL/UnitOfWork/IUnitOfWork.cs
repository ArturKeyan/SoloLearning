using SoloLearning.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRoomRepository RoomRepository { get; }
        Task SaveAsync();
    }
}
