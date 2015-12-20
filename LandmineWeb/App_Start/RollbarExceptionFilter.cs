using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using RollbarSharp;

namespace LandmineWeb.App_Start
{
    public class RollbarExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            (new RollbarClient()).SendException(filterContext.Exception);
        }
    }
}