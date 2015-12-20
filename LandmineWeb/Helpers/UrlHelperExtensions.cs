using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandmineWeb.Helpers
{
    public static class UrlHelperExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string actionName, string controllerName, object routeValues)
        {
            return url.Action(actionName, controllerName, routeValues, url.RequestContext.HttpContext.Request.Url.Scheme);
        }

        public static string AbsoluteContent(this UrlHelper url, string path)
        {
            var uri = new Uri(path, UriKind.RelativeOrAbsolute);

            if (uri.IsAbsoluteUri)
            {
                return uri.ToString();
            }

            var requestUrl = url.RequestContext.HttpContext.Request.Url;
            var builder = new UriBuilder(requestUrl.Scheme, requestUrl.Host, requestUrl.Port);

            builder.Path = VirtualPathUtility.ToAbsolute(path);
            uri = builder.Uri;

            return uri.ToString();
        }
    }
}