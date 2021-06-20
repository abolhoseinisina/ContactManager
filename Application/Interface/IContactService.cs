using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IContactService
    {
        public Task<Contact> Get(int id);
        public Task<ICollection<Contact>> List();
        public Task Create(Contact contact);
        public Task Delete(int id);
        public Task Update(Contact contact);
    }
}
