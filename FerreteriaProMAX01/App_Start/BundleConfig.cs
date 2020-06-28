using System.Web.Optimization;

namespace FerreteriaProMAX01
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/morris/morris.min.js",
                "~/Content/menu/metisMenu.min.js",
                   "~/scripts/js/sb-admin-2.min.js" ,
                    "~/scripts/jquey/jquery-3.4.1.min.js" ,
                        "~/Scripts/modernizr-2.8.3.min.js",
                         "~/scripts/jquey/jquery.validate.min.js",
                          "~/scripts/jquey/jquery.validate.unobtrusive.js",
                    "~/Scripts/jquery-3.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/nuevos/sb-admin-2.min.css",
                "~/Content/nuevos/sb-admin-2.css",
               "~/Content/menu/metisMenu.min.css",
                 "~/Content/font-awesome/css/font-awesome.min.css",
                 "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}

