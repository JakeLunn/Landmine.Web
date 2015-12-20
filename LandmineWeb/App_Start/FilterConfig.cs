using LandmineWeb.App_Start;

using System.Web.Mvc;

namespace LandmineWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new RollbarExceptionFilter());
            filters.Add(new HandleErrorAttribute());

        }
    }
}
