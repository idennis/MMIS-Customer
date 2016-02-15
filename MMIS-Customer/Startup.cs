using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MMIS_Customer.Startup))]
namespace MMIS_Customer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
