using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Awesome_SPA.Services;

[assembly: WebActivator.PostApplicationStartMethod(typeof(Awesome_SPA.App_Start.Startup), "Start")]

namespace Awesome_SPA.App_Start
{
    public static class Startup
    {
        
        public static void Start()
        {
            var resolver = GlobalConfiguration.Configuration.DependencyResolver;
            var notifier = resolver.GetService(typeof(IScheduler));
        }
    }
}