using System.Web;
using System.Web.Optimization;

namespace Library
{
    public class BundleConfig
    {
        
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/LibraryStyle")
                .Include("~/vendor/bootstrap/css/bootstrap.min.css",
                "~/css/heroic-features.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Login_v19")
                .Include("~/Login_v19/images/icons/favicon.ico",
                "~/Login_v19/vendor/bootstrap/css/bootstrap.min.css",
                "~/Login_v19/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Login_v19/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                "~/Login_v19/vendor/animate/animate.css",
                "~/Login_v19/vendor/css-hamburgers/hamburgers.min.css",
                "~/Login_v19/vendor/animsition/css/animsition.min.css",
                "~/Login_v19/vendor/select2/select2.min.css",
                "~/Login_v19/vendor/daterangepicker/daterangepicker.css",
                "~/Login_v19/css/util.css",
                "~/Login_v19/css/main.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap")
                .Include("~/vendor/jquery/jquery.min.js",
                "~/ vendor / bootstrap / js / bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Login_v19")
                .Include("~/Login_v19/vendor/jquery/jquery-3.2.1.min.js",
                "~/Login_v19/vendor/animsition/js/animsition.min.js",
                "~/ Login_v19 / vendor / bootstrap / js / popper.js",
                "~/Login_v19/vendor/bootstrap/js/bootstrap.min.js",
                "~/Login-_v19/vendor/select2/select2.min.js",
                "~/Login_v19/vendor/daterangepicker/moment.min.js",
                "~/Login_v19/vendor/daterangepicker/daterangepicker.js",
                "~/Login_v19/vendor/countdowntime/countdowntime.js",
                "~/Login_v19/js/main.js"));
        }
    }
}
