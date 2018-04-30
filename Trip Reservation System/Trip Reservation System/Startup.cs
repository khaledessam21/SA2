using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trip_Reservation_System.Startup))]
namespace Trip_Reservation_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
