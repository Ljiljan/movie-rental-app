using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(movie_rental_app.Startup))]
namespace movie_rental_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
