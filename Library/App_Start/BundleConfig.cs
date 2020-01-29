using System.Web;
using System.Web.Optimization;

namespace Library
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/LibraryStyle")
                .Include("~/vendor/bootstrap/css/bootstrap.min.css",
                "~/css/heroic-features.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap")
                .Include("~/vendor/jquery/jquery.min.js",
                "~/ vendor / bootstrap / js / bootstrap.bundle.min.js"));
        }
    }
}
