using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{ChapterList}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    ChapterList = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "SendResults",
                url: "{controller}/{action}/{chapter}/{example}",
                defaults: new
                {
                    controller = "Home",
                    action = "SendResults",
                    chapter = UrlParameter.Optional,
                    example = UrlParameter.Optional
                }
            );


        }
    }
}
