using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1
{
    public class DataAccessLayer
    {
        public static List<Models.Contact> SelectData()
        {
            using (var db = new ContactsContext())
            {
                var contacts = db.Contacts.Select(m => m)
                    .OrderBy(m => m.Name)
                    .Include(p => p.Position)
                    //.Skip(pageSize * (pageNumber - 1))
                    .Take(10)
                    .ToList(); //.Take(pageSize);
                return contacts;
            }
        }
    }
}