using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace LandmineWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Play",
                url: "play",
                defaults: new { controller = "Game", action = "Play" });

            routes.MapRoute(
                name: "Leaderboard",
                url: "leaderboard",
                defaults: new { controller = "Leaderboard", action = "Index" });

            routes.MapRoute(
                name: "Instructions",
                url: "how-to-play",
                defaults: new { controller = "Home", action = "Instructions" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}