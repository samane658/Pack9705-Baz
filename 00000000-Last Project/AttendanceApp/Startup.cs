using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttendanceApp.Startup))]
namespace AttendanceApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
