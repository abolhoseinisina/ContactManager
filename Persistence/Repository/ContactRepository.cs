using Application.Interface;
using Domain.Model;
using Persistence.Context;

namespace Persistence.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactContext context) : base(context)
        {
        }
    }
}
