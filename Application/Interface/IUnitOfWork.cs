using System;

namespace Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IContactRepository ContactRepository { get;}
        public void Save();
    }
}
