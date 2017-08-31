using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MyGame.UI.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyGame.UI.Startup))]
namespace MyGame.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);            
        }
    }
}
