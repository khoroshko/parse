using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parse.BO.Startup))]
namespace Parse.BO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
