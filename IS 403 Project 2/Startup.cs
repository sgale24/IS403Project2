using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IS_403_Project_2.Startup))]
namespace IS_403_Project_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
