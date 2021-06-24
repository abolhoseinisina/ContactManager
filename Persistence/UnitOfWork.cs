using Application.Interface;
using Persistence.Context;
using Persistence.Repository;
using System;
using System.Threading.Tasks;

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

        public async Task Save()
        {
            try
            {
                await context.SaveChangesAsync(); 
            }
            catch
            { 
                throw new InvalidOperationException("Error saving data to DB."); 
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
