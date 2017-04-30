using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App.Marriage.Startup))]
namespace App.Marriage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
