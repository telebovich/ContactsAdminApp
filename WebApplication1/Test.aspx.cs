using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {
        private int count;
        private static int staticCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            count = int.Parse(Request.QueryString["test"]);
            staticCount = int.Parse(Request.QueryString["test"]);

            if (IsPostBack)
            {
                Label1.Text = (++count).ToString();
                Label2.Text = (++staticCount).ToString();      
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {

        }
    }
}