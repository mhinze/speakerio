using System;
using System.Web;
using System.Web.Mvc;

namespace SpeakerIO.Web.Extensions
{
    public static class UrlExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string action, string controller, string returnUrl)
        {
            string relativeUrl = url.Action(action, controller, new {returnUrl});
            string root = url.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
            return root + VirtualPathUtility.ToAbsolute("~/" + relativeUrl);
        }
    }
}