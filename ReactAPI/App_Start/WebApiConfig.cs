using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ReactAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute(
                  "http://localhost:3000",
                  "*",
                  "*");

            config.EnableCors(cors);

            config.Formatters.Remove(
                config.Formatters.XmlFormatter
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

          //  config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}   

