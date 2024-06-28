using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Inventory_Management_System.StartupOwin))]

namespace Inventory_Management_System
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
