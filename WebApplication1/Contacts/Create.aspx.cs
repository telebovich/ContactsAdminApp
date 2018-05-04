using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Contacts
{
    public partial class Create : System.Web.UI.Page
    {
        private ContactsContext db = new ContactsContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Models.Contact c = new Models.Contact
            {
                Name = Name.Text,
                Email = Email.Text,
                LandlinePhone = Telephone.Text,
                CellPhone = Mobile.Text
            };
            if (DateOfBirth.Text != "")
            {
                c.DateOfBirth = Convert.ToDateTime(DateOfBirth.Text);
            }
            db.Contacts.Add(c);
            db.SaveChanges();
            Response.Redirect("~/");
        }
    }
}