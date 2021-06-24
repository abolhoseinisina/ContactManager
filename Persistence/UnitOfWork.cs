using Application.Interface;
using Persistence.Context;
using Persistence.Repository;
using System;

namespace Persistence
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ContactContext context;
        public IContactRepository ContactRepository { get; }

        public UnitOfWork(ContactContext context, IContactRepository contactRepository)
        {
            this.context = context;
            ContactRepository = contactRepository;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
