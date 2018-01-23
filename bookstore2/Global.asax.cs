using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using bookstore2.Models;
using bookstore2.Validation;
using bookstore2.ValueProviders;
using bookstore2.MyBookModelBinders;

namespace bookstore2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelBinders.Binders.Add(typeof(Book), new BookModelBinder());
            ValueProviderFactories.Factories.Add(new BrowserValueProviderFactory());
            ModelValidatorProviders.Providers.Add(new MyValidationProvider());
            Database.SetInitializer(new BookDbIntilizer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
