using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandmineWeb.HtmlHelpers
{
    public static class UrlHelperExtensions
    {
        public static string AbsoluteAction(this UrlHelper url, string actionName, string controllerName, object routeValues)
        {
            return url.Action(actionName, controllerName, routeValues, url.RequestContext.HttpContext?.Request?.Url?.Scheme ?? "http");
        }

        public static string AbsoluteContent(this UrlHelper url, string path)
        {
            var uri = new Uri(path, UriKind.RelativeOrAbsolute);

            if (uri.IsAbsoluteUri)
            {
                return uri.ToString();
            }

            var requestUrl = url.RequestContext.HttpContext.Request.Url;
            var scheme = requestUrl?.Scheme ?? "http";

            Debug.Assert(requestUrl != null, "requestUrl != null");
            var builder = new UriBuilder(scheme, requestUrl.Host, requestUrl.Port) { Path = VirtualPathUtility.ToAbsolute(path) };

            uri = builder.Uri;

            return uri.ToString();
        }
    }
}