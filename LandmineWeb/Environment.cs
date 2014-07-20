using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace LandmineWeb
{
    public static class Environment
    {
        private static Lazy<string> environmentName;

        static Environment()
        {
            environmentName = new Lazy<string>(() => WebConfigurationManager.AppSettings["Landmine.Environment"] ?? "production");
        }

        public static string Name
        {
            get { return environmentName.Value; }
        }

        public static bool IsProduction
        {
            get { return Name == "production"; }
        }

        public static bool IsDevelopment
        {
            get { return Name == "development"; }
        }

    }
}