﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace NorthwindApiTenta1
{
    public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
        HttpConfiguration config = GlobalConfiguration.Configuration;

        config.Formatters.JsonFormatter
                    .SerializerSettings
                    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }
  }
}
