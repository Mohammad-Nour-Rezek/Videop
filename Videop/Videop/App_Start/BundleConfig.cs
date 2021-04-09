using System.Web;
using System.Web.Optimization;

namespace Videop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Now this bundle is not reference anywhere and it's uswed for client side validation
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        // So here all files tha match this pattern: "~/Scripts/jquery.validate*"
                        "~/Scripts/jquery.validate*"));
                        // Will be combine and compressed and will be available for download at this address: "~/bundles/jqueryval"

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // We don't add minified files here cuz with this bundels we already get minification when build
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));
        }
    }
}
