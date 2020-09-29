using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactManagementSystem.Startup))]
namespace ContactManagementSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
