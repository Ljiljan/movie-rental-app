using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace movie_rental_app
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable attribute routes
            routes.MapMvcAttributeRoutes();

        //    routes.MapRoute(
        //        "MoviesByRelease",
        //        "{controller}/release/{yr}/{mon}",
        //        new { controller = "Movies", action = "ReleaseDateSort" },
        //        // Regex below to prevent entering more than 4 digits for yr and 2 for month
        //        // @ is used to break non-escape character "\"
        //        new { yr = @"\d{4}|10000", mon = @"\d{2}" }
        //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
