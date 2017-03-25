using System.Web;
using System.Web.Optimization;

namespace BulgarianCreators.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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

            bundles.Add(new ScriptBundle("~/js/libs").Include(
                "~/js/libs/bootstrap.min.js",
                "~/js/libs/jqBootstrapValidation.js",
                "~/js/libs/imagesloaded.pkgd.min.js",
                "~/js/libs/imagesloaded.js",
                "~/js/libs/jquery.magnific-popup.min.js",
                "~/js/libs/isotope.pkgd.min.js",
                "~/js/libs/ParallaxScrolling.js",
                "~/js/libs/jquery.mailchimp.js",
                "~/js/libs/wow.min.js",
                "~/js/libs/jquery.fittext.js",
                "~/js/libs/jquery.lettering.js",
                "~/js/libs/jquery.textillate.js",
                "~/js/main.js"));

                //"~/js/libs/bootstrap.min.js")
                //"~/js/libs/jqBootstrapValidation.js")
                //"~/js/libs/imagesloaded.pkgd.min.js")
                //"~/js/libs/imagesloaded.js")
                //"~/js/libs/jquery.magnific-popup.min.js")
                //"~/js/libs/isotope.pkgd.min.js")
                //"~/js/libs/ParallaxScrolling.js")
                //"~/js/libs/jquery.mailchimp.js")
                //"~/js/libs/wow.min.js")
                //"~/js/libs/jquery.fittext.js")
                //"~/js/libs/jquery.lettering.js")
                //"~/js/libs/jquery.textillate.js")

                //@Scripts.Render("~/js/main.js")

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/style.css",
                      "~/Content/animate.css",
                      "~/Content/iline-icons.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/normalize.min.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.theme.css",
                      "~/Content/owl.transitions.css",
                      "~/Content/responsive.css"));
        }
    }
}
