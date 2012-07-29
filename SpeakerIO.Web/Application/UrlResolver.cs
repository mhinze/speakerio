using System;
using System.Web;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace SpeakerIO.Web.Application
{
    public class UrlResolver : IUrlResolver
    {
        readonly UrlHelper _helper;

        public UrlResolver(UrlHelper helper)
        {
            _helper = helper;
        }

        public string AbsoluteAction([AspMvcAction] string action,
                                     [AspMvcController] string controller,
                                     object routeValues)
        {
            string relativeUrl = _helper.Action(action, controller, routeValues);
            if (_helper.RequestContext.HttpContext.Request.Url != null)
            {
                string root = _helper.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
                return root + VirtualPathUtility.ToAbsolute("~/" + relativeUrl);
            }
            return null;
        }

        public bool IsLocalUrl(string url)
        {
            return _helper.IsLocalUrl(url);
        }
    }

    public static class UrlExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string action, string controller, object routeValues)
        {
            return new UrlResolver(url).AbsoluteAction(action, controller, routeValues);
        }
    }

}