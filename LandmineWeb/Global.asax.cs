﻿using LandmineWeb.App_Start;
using RollbarSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LandmineWeb
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

#if DEBUG
            System.Web.Optimization.BundleTable.EnableOptimizations = false;
#endif

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(NinjectKernelFactory.Kernel);

            GlobalFilters.Filters.Add(new RollbarExceptionFilter());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError().GetBaseException();

            (new RollbarClient()).SendException(exception);
        }
    }
}
