using System.Web;
using System.Web.Optimization;

namespace LandmineWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
   
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/application-scripts").Include(
                        "~/bower_components/landmine.js/dist/landmine.js"));

            bundles.Add(new ScriptBundle("~/bundles/landmine-integration").Include(
                        "~/Scripts/q.js",
                        "~/Scripts/knockout.min.js",
                        "~/Scripts/LM/LM.modal.js",
                        "~/Scripts/LM/LM.Score.js",
                        "~/Scripts/LM/Binding/HighScore.js",
                        "~/Scripts/LM/Binding/HighScoreList.js",
                        "~/Scripts/LM/Integration/HighScoreIntegration.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
