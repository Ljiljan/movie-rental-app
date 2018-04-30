using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace movie_rental_app
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Setting up the Json Formater with Contract Resolver
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            // Setting up the CamelCase formatter via Newtonsoft serialization object
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Formating the above object
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
