using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project.ClothingMall.Web.Startup))]
namespace Project.ClothingMall.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
