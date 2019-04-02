using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IssueTicketingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            ModelBinders.Binders.Add(typeof(decimal),new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?),new DecimalModelBinder());
        }
    }
}
