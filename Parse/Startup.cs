using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parse.Startup))]
namespace Parse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
