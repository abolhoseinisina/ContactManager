using Domain.Model;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface IContactService
    {
        public Contact Get(int id);
        public ICollection<Contact> List();
        public void Create(Contact contact);
        public void Delete(int id);
        public void Update(Contact contact);
    }
}
