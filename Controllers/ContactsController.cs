using Microsoft.AspNetCore.Mvc;
using Web_API_CRUD_with_Internal_DB.Data;
using Web_API_CRUD_with_Internal_DB.Models;

namespace Web_API_CRUD_with_Internal_DB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(dbContext.Contacts.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContactRequest addContactRequest) 
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest) 
        { 
            var contact = dbContext.Contacts.Find(id);

            if (contact != null) 
            { 
                contact.FullName = updateContactRequest.FullName;
                contact.Address = updateContactRequest.Address;
                contact.Phone = updateContactRequest.Phone;
                contact.Email = updateContactRequest.Email;

                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();        
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContacts(AddContactRequest addContactRequest)
        {
            return Ok();
        }


    }
}
