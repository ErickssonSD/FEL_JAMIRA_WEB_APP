using System.Web;
using System.Web.Optimization;

namespace FEL_JAMIRA_WEB_APP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                        "~/Scripts/Menu/bootstrap.bundle.min.js",
                        "~/Scripts/Menu/dataTables.bootstrap4.js",
                        "~/Scripts/Menu/jquery.easing.min.js",
                        "~/Scripts/Menu/jquery.min.js",
                        "~/Scripts/Menu/sb-admin-2.min.js",
                        "~/Scripts/Menu/jquery.dataTables.js"));

            bundles.Add(new ScriptBundle("~/bundles/register").Include(
            "~/Scripts/Mask.js",
            "~/Scripts/Util.js",
            "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/loginJs").Include(
            "~/Scripts/Areas/Login.js"));

            bundles.Add(new ScriptBundle("~/bundles/menuFornecedor").Include(
            "~/Scripts/Areas/MenuFornecedor.js"));

            bundles.Add(new ScriptBundle("~/bundles/menuCliente").Include(
            "~/Scripts/Areas/MenuCliente.js"));

            bundles.Add(new ScriptBundle("~/bundles/menuEstacionamento").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/Areas/Estacionamento.js"));

            bundles.Add(new ScriptBundle("~/bundles/menuCarro").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/Areas/Carro.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/menu").Include(
                      "~/Content/Menus/all.css",
                      "~/Content/Menus/dataTables.bootstrap4.css",
                      "~/Content/Menus/sb-admin-2.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Ballon.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/loginCss").Include(
                      "~/Content/Areas/Login.css"));

            bundles.Add(new StyleBundle("~/Content/menuUsuarios").Include(
                    "~/Content/Areas/MenuUsuarios.css"));

            bundles.Add(new StyleBundle("~/Content/menuCarro").Include(
                    "~/Content/Areas/Carro.css"));

            bundles.Add(new StyleBundle("~/Content/menuEstacionamento").Include(
                    "~/Content/Areas/Estacionamento.css"));
        }
    }
}
