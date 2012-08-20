using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SpeakerIO.Web.Data.Model;

namespace SpeakerIO.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapBundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof (User), new UserModelBinder());
BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);


        }
    }
}