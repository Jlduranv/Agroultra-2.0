using System.Web;
using System.Web.Optimization;

namespace EVALUACION_2_TP {
    public class BundleConfig {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {           
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/url/https://cdnjs.cloudflare.com/ajax/libs/magnific-popup.js/1.1.0/magnific-popup.min.css",
                    "~/Content/dist/magnific-popup.css",
                    "~/Content/css/styles.css"));
        }
    }
}
