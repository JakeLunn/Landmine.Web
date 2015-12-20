using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;

namespace LandmineWeb
{
    public static class Environment
    {
        private static readonly Lazy<string> _environmentName;

        static Environment()
        {
            _environmentName = new Lazy<string>(() => WebConfigurationManager.AppSettings["Landmine.Environment"] ?? "production");
        }

        public static string Name => _environmentName.Value;
        public static bool IsProduction => Name == "production";
        public static bool IsDevelopment => Name == "development";
    }
}