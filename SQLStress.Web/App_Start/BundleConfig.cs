using System.Web;
using System.Web.Optimization;

namespace SQLStress.Web
{
    public class BundleConfig
    {
        //For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Vendors/js").Include(
                "~/Resources/Vendors/js/jquery-3.3.1.min.js", 
                "~/Resources/Vendors/js/tether.min.js",
                "~/Resources/Vendors/js/bootstrap.min.js",
                "~/Resources/Vendors/js/remodal.min.js",
				"~/Resources/Vendors/js/jquery.unbtrusive-ajax.js",
				"~/Resources/Vendors/js/jquery.validate.min.js",
				"~/Resources/Vendors/js/jquery.validate.unobtruive.min.js"
				));

            bundles.Add(new StyleBundle("~/Vendors/css").Include(
                "~/Resources/Vendors/css/bootstrap.min.css",
                "~/Resources/Vendors/css/fontawesome-all.min.css",
                "~/Resources/Vendors/css/remodal.css",
                "~/Resources/Vendors/css/remodal-default-theme.css"
                ));

            bundles.Add(new StyleBundle("~/Shared/css").Include(
                "~/Resources/Content/Style/Shared/Site.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
