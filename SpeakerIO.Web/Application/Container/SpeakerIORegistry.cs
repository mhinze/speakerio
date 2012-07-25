using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap.Configuration.DSL;

namespace SpeakerIO.Web.Application.Container
{
    public class SpeakerIORegistry : Registry
    {
        public SpeakerIORegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            For<HttpContextBase>().HybridHttpOrThreadLocalScoped()
                .Use(HttpContext.Current == null ? null : new HttpContextWrapper(HttpContext.Current));

            For<IUrlResolver>().HybridHttpOrThreadLocalScoped()
                .Use(ctx => new UrlResolver(new UrlHelper(HttpContext.Current.Request.RequestContext, RouteTable.Routes)));
        }
    }
}