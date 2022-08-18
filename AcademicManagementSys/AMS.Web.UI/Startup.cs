using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("AcademicManagementSys",typeof(AMS.Web.UI.Startup))]
namespace AMS.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
           app.MapSignalR();
        }
    }
}
