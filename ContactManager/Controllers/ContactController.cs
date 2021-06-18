using Application.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public ActionResult<ICollection<Contact>> List()
        {
            return Ok(contactService.List());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            return Ok(contactService.Get(id));
        }

        [HttpPost]
        public ActionResult Create([FromForm] Contact contact)
        {
            contactService.Create(contact);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromForm] Contact contact)
        {
            contactService.Update(contact);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromForm] int id)
        {
            contactService.Delete(id);
            return Ok();
        }
    }
}
