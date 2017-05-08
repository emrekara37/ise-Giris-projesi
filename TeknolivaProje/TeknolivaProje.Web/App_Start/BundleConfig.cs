using System.Web.Optimization;

namespace TeknolivaProje.Web
{
  public class BundleConfig
  {
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js",
                  "~/Scripts/morris/raphael.min.js",
                  "~/Scripts/morris/morris-data.js",
                  "~/Scripts/morris/morris.min.js"
                  ));

      // Notify , SweetAlert, GlobalJs Bundle
      bundles.Add(new ScriptBundle("~/bundles/deletejs").Include(
        "~/Scripts/sweetalert.min.js",
        "~/Scripts/notify.min.js",
        "~/Scripts/global.js"
        ));
      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

      
      bundles.Add(new StyleBundle("~/Content/css").Include(
        
                "~/Content/bootstrap.min.css",
                "~/Content/sb-admin.css",
                "~/Content/morris.css",
                "~/font-awesome/css/font-awesome.min.css",
                "~/Content/site.css",
                "~/Content/sweetalert.css"));
    }
  }
}
