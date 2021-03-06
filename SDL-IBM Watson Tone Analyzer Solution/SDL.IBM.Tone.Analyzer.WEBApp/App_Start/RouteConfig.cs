﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SDL.IBM.Tone.Analyzer.WEBApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{q}",
                defaults: new { controller = "Home", action = "Index", q = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Custom",
              url: "{controller}/{action}/{customText}",
              defaults: new { controller = "Home", action = "Custom", customText = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "Api",
             url: "{controller}/{action}/{text}",
             defaults: new { controller = "ToneAnalyzer", action = "getToneAnalyzer", text = "" }
         );
        }
    }
}
