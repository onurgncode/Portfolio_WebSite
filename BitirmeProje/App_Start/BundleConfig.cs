using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using System.Web;
using System.Web.Optimization;

namespace CodeRepository.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*
            var nullBulider = new NullBuilder();
            var nullOrderer = new NullOrderer();

            BundleResolver.Current = new CustomBundleResolver();
            var commonStyleBundle = new CustomStyleBundle("~/Bundle/sass");

            commonStyleBundle.Include(); //boş
            commonStyleBundle.Orderer = nullOrderer;
            bundles.Add(commonStyleBundle);
            */
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css", "~/Content/magnific-popup.css",
                      "~/Content/jquery-ui.css", "~/Content/owl.carousel.min.css", "~/Content/owl.theme.default.min.css",
                      "~/Content/aos.css", "~/Content/fancybox.min.css", "~/Content/style.css"));
            bundles.Add(new StyleBundle("~/Content/css/admin").Include("~/Content/admincss/bootstrap.min.css"
                , "~/Content/admincss/owl.carousel.min.css", "~/Content/admincss/style.css", "~/Content/admincss/tempusdominus-bootstrap-4.min.css"));
        }
    }
}