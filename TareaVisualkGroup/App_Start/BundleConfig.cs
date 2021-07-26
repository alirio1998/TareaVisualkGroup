using System.Web;
using System.Web.Optimization;

namespace TareaVisualkGroup
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/plugins/jquery/jquery.min.js"));



            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/Content/Pluggins").Include(
                      "~/Content/dist/js/main.js",
                      "~/Content/plugins/toastr/toastr.min.js",
                      "~/Content/plugins/sweetalert2/sweetalert2.min.js",
                      "~/Content/plugins/datatables/dataTables.js",
                      "~/Content/plugins/jquery-validation/jquery.validate.min.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/plugins/loading/jquery.loadingModal.css",
                      "~/Content/bootstrap.css",
                      "~/Content/plugins/fontawesome-free/css/all.css",
                      "~/Content/site.css",
                      "~/Content/estilos.css",

                      "~/Content/plugins/toastr/toastr.min.css",
                      "~/Content/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css",
                      "~/Content/plugins/select2/css/select2.min.css",
                      "~/Content/plugins/select2-bootstrap4-theme/select2-bootstrap4.min.css",
                      "~/Content/plugins/datatables/dataTables.bootstrap4.css"));
        }
    }
}
