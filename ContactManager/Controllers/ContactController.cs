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
        public async Task<ActionResult<ICollection<Contact>>> List()
        {
            var contactList = await contactService.List();
            if (contactList.Count != 0) return Ok(contactList);
            return NotFound("There are no contacts");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var contact = await contactService.Get(id);
            if (contact != null) return Ok(contact);
            return NotFound("Could not find a contact with this id: " + id);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] Contact contact)
        {
            try
            {
                await contactService.Create(contact);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] Contact contact)
        {
            try
            {
                await contactService.Update(contact);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromForm] int id)
        {
            try
            {
                await contactService.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
