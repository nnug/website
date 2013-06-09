using System.Web.Optimization;

namespace NNUG.WebSite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/scripts/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/less/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/style/theme.css",
                "~/Content/less/responsive.css",
                "~/Content/style/theme-responsive.css",
                "~/Content/style/site.css"));
        }
    }
}