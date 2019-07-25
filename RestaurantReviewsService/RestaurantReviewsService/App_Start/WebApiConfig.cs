using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestaurantReviewsService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithParameters", 
                routeTemplate: "api/{controller}/{name}",
                new {name = RouteParameter.Optional }
                );
        }
    }
}
