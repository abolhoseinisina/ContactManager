using Application.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Create(Contact contact)
        {
            if (contact.Id != 0) throw new InvalidOperationException("Do not include id in your request.");
            await unitOfWork.ContactRepository.Insert(contact);
            await unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await unitOfWork.ContactRepository.Delete(id);
            await unitOfWork.Save();
        }

        public async Task<Contact> Get(int id)
        {
            return await unitOfWork.ContactRepository.Get(id);
        }

        public async Task<ICollection<Contact>> List()
        {
            return await unitOfWork.ContactRepository.List();
        }

        public async Task Update(Contact contact)
        {
            //if (await Get(contact.Id) == null) throw new InvalidOperationException("Could not find an entity with this id: " + contact.Id);
            await unitOfWork.ContactRepository.Update(contact);
            await unitOfWork.Save();
        }
    }
}
