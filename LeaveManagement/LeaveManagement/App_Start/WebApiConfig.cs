using LeaveManagement.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Cors;
namespace LeaveManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // Enable CORS globally
            var cors = new EnableCorsAttribute("http://127.0.0.1:5500", "*", "*"); // Only allow specific origins
            config.EnableCors(cors); // Enable the CORS configuration globally

            // Add JWT Authentication filter (make sure CORS comes first)
            config.Filters.Add(new JwtAuthenticationFilter());

            // Route configuration
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
