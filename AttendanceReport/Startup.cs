using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttendanceReport.Startup))]
namespace AttendanceReport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
