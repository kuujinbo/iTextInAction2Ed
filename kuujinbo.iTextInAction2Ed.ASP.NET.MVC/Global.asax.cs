using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using iTextSharp.text.io;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            StreamUtil.AddToResourceSearch(HttpContext.Current.Server.MapPath("~/AsianFonts/iTextAsian.dll"));
        }
    }
}
