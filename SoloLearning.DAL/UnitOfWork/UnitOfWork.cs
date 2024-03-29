﻿using Microsoft.EntityFrameworkCore;
using SoloLearning.DAL.Implementations;
using SoloLearning.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearning.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext context;
        private IRoomRepository roomRepository;
        private IMessageRepository messageRepository;

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }

        public IMessageRepository MessageRepository
        {
            get
            {
                return messageRepository ?? (messageRepository = new MessageRepositry(context));
            }
        }

        public IRoomRepository RoomRepository
        {
            get
            {
                return roomRepository ?? (roomRepository = new RoomRepository(context));
            }
        }


        #region save

        public async Task SaveAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                DbUpdateExceptionHandler(ex);
            }
        }

        private void DbUpdateExceptionHandler(DbUpdateException ex)
        {
            var builder = new StringBuilder();

            foreach (var result in ex.Entries)
            {
                builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
            }

            throw new Exception(builder.ToString(), ex);
        }

        #endregion

        #region Diposable   

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
