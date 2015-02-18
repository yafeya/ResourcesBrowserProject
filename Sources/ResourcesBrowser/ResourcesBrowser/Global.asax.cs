﻿using ResourcesBrowser.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ResourcesBrowser
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var resourcesUri = ConfigurationManager.AppSettings["resourcesUri"];
            var resourcesPath = Server.MapPath(resourcesUri);
            ResourcesManager.Manager.SetResourcesPath(resourcesPath);
            ResourcesManager.Manager.SetRootDirName(resourcesUri);
        }
    }
}
