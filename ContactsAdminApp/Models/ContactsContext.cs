using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactsAdminApp.Models
{
    public class ContactsContext: DbContext
    {
        public ContactsContext(): base("DefaultConnection")
        {

        }

        public static ContactsContext Create()
        {
            return new ContactsContext();
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}