﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Rotativa;

namespace Inventory_Management_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public object RotativaConfiguration { get; private set; }

        protected void Application_Start()
        {
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            


        }


    }
}
