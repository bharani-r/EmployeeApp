using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeUI.Startup))]
namespace EmployeeUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
