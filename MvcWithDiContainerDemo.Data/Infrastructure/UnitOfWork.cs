using MvcWithDiContainerDemo.Data.Entities;
using MvcWithDiContainerDemo.Data.Repositories;
using System;
using System.Data.Entity.Core.Objects;

namespace MvcWithDiContainerDemo.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        private MessageRepository _messages;

        public UnitOfWork(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }

            _context = context;
        }

        #region IUnitOfWork Members

        public IRepository<Message> Messages
        {
            get
            {
                if (_messages == null)
                {
                    _messages = new MessageRepository(_context);
                }

                return _messages;
            }
        }

        

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion

    }
}