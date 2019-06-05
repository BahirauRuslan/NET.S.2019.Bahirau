using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DependencyResolver;
using Ninject;

namespace WebPL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IKernel Resolver { get; } = new StandardKernel();

        protected void Application_Start()
        {
            AutoMapperConfig.Configure();
            Resolver.ConfigurateResolver();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
