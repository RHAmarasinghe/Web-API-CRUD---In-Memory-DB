﻿using Microsoft.AspNetCore.Mvc;
using Web_API_CRUD_with_Internal_DB.Data;

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
    }
}
