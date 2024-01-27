using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EMS_MVC_30121023
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //To enable attribute routing
            routes.MapMvcAttributeRoutes();

            //Conventional Routing

            //routes.MapRoute(
            //    name: "AddDepartment",
            //    url: "AddDepartment",
            //    defaults: new { controller = "Department", action = "Create", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "ModifyDepartment",
            //    url: "ModifyDepartment/{id}",
            //    defaults: new { controller = "Department", action = "Edit", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Department", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
