using System;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IContactRepository ContactRepository { get;}
        public Task Save();
    }
}
