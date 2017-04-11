using System.Web;
using System.Web.Optimization;

namespace WebUI.TestService
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepickerScripts").Include(
                "~/Scripts/jquery.datetimepicker.full.min.js",
                "~/Scripts/datetimepickerInit.js"));

            bundles.Add(new ScriptBundle("~/bundles/timerScripts").Include(
                "~/Scripts/jquery.simple.timer.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/layoutStyles.css"));

            bundles.Add(new StyleBundle("~/Content/testCreationStyles").Include(
                    "~/Content/jquery.datetimepicker.min.css",
                    "~/Content/testCreationStyle.css"));

            bundles.Add(new StyleBundle("~/Content/personalAreaStyles").Include(
                     "~/Content/personalAreaStyles.css"));


            bundles.Add(new StyleBundle("~/Content/adminStyles").Include(
                "~/Content/adminStyles.css"));

            bundles.Add(new StyleBundle("~/Content/timerStyles").Include(
                "~/Content/timerStyles.css"));

            bundles.Add(new ScriptBundle("~/bundles/personalAreaScripts").Include(
                "~/Scripts/personalAreaScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/layoutScripts").Include(
                "~/Scripts/layoutScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminScripts").Include(
                "~/Scripts/adminScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/testCreationScripts").Include(
                "~/Scripts/testCreationScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/testExecutionScripts").Include(
                "~/Scripts/testExecutionScripts.js"));
        }
    }
}
