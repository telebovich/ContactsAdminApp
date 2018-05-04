using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactsAdminApp.Startup))]
namespace ContactsAdminApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
