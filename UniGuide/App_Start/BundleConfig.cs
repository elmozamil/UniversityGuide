using System.Web;
using System.Web.Optimization;

namespace UniGuide
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/jquery.signalR-2.2.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/Custom").Include(
                    "~/Custom/ParaFormatting.js",
                    "~/Scripts/wow.js",
                    "~/Scripts/jquery.nicescroll.js",
                    "~/Scripts/jquery.easing.min.js",
                    "~/Scripts/jquery.mixitup.min.js",
                    "~/Scripts/imagesloaded.pkgd.min.js",
                    "~/Scripts/skillset.js",
                    "~/Scripts/owl.carousel.js",
                    "~/Scripts/scrollupto.js",
                    "~/Scripts/main.js",
                    "~/Custom/behavior.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/jquery-ui.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Custom/ParaFormatting.css",
                      "~/Custom/ListData.css",
                      "~/Content/style.css",
                      "~/Content/owl.theme.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.transitions.css",
                      "~/Content/skillset.css",
                      "~/Contetnt/animate.css"));
        }
    }
}
