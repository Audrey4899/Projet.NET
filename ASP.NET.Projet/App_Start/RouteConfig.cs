using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET.Projet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AjouterNote",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "AjouterNote" }
            );

            routes.MapRoute(
                name: "RechercheEleve",
                url: "{controller}/{action}/{name}",
                defaults: new { controller = "Home", action = "RechercheEleve" }
            );

            routes.MapRoute(
                name: "DetailEleve",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DetailEleve" }
            );

            routes.MapRoute(
                name: "DetailClasse",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DetailClasse" }
            );

            routes.MapRoute(
                name: "Eleves",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "ListeEleves", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Classes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "ListeClasses", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
