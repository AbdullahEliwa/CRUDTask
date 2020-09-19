using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDTask.Startup))]
namespace CRUDTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
