using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace SpeakerIO.Web
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/jquery-1.*",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive-custom-for-bootstrap.js",
                "~/Scripts/bootstrap.min.js"
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/bootstrap.css"
                ));
            bundles.Add(new StyleBundle("~/content/css-responsive").Include(
                "~/Content/bootstrap-responsive.css"
                ));
        }
    }
}