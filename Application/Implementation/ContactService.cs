using Application.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Contact contact)
        {
            unitOfWork.ContactRepository.Insert(contact);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            unitOfWork.ContactRepository.Delete(id);
            unitOfWork.Save();
        }

        public Contact Get(int id)
        {
            return unitOfWork.ContactRepository.Get(id);
        }

        public ICollection<Contact> List()
        {
            return unitOfWork.ContactRepository.List();
        }

        public void Update(Contact contact)
        {
            unitOfWork.ContactRepository.Update(contact);
            unitOfWork.Save();
        }
    }
}
