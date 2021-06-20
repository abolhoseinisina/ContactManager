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

        public UnitOfWork(ContactContext context)
        {
            this.context = context;
            ContactRepository = new ContactRepository(this.context);
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
