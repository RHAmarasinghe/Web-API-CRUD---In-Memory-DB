using Microsoft.EntityFrameworkCore;
using Web_API_CRUD_with_Internal_DB.Models;

namespace Web_API_CRUD_with_Internal_DB.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
