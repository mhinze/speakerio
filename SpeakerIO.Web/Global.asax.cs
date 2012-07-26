using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using SpeakerIO.Web.Data;
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
        }
    }

    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var userIdentifier = controllerContext.HttpContext.User.Identity.Name;
            using (var db = new DataContext())
            {
                return db.Users.Single(x => x.Identifier == userIdentifier);
            }
        }
    }
}