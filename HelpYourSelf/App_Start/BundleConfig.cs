using System.Web;
using System.Web.Optimization;

namespace HelpYourSelf
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Plugins/jQuery/jQuery-2.1.4.min.js",
                        "~/Plugins/jQueryUI/jquery-ui.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Plugins/select2/select2.full.min.js",
                      "~/Plugins/input-mask/jquery.inputmask.js",
                      "~/Plugins/input-mask/jquery.inputmask.date.extensions.js",
                      "~/Plugins/input-mask/jquery.inputmask.extensions.js",
                      "~/Scripts/moment.js",
                      "~/Plugins/datatables/jquery.dataTables.min.js",
                      "~/Plugins/daterangepicker/daterangepicker.js",
                      "~/Plugins/colorpicker/bootstrap-colorpicker.min.js",
                      "~/Plugins/timepicker/bootstrap-timepicker.min.js",
                      "~/Plugins/slimScroll/jquery.slimscroll.min.js",
                      "~/Plugins/iCheck/icheck.min.js",
                      "~/Plugins/fastclick/fastclick.min.js",
                      "~/dist/js/app.min.js",
                      "~/dist/js/demo.js",
                      "~/Plugins/ckeditor/ckeditor.js",
                      "~/Plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"
                      ));


            bundles.Add(new ScriptBundle("~/bundles/Common").Include(
                "~/Plugins/Validation/iValidation.js",
                "~/JQuery/Common/site.layout.js",
                "~/JQuery/Common/site.common.js",
                "~/JQuery/Common/site.all.combo.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/dist/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/dist/ionicons-2.0.1/css/ionicons.min.css",
                      "~/Plugins/daterangepicker/daterangepicker-bs3.css",
                      "~/Plugins/iCheck/all.css",
                      "~/Plugins/colorpicker/bootstrap-colorpicker.min.css",
                      "~/Plugins/timepicker/bootstrap-timepicker.min.css",
                      "~/Plugins/select2/select2.min.css",
                      "~/dist/css/AdminLTE.min.css",
                      "~/dist/css/skins/_all-skins.min.css",
                      "~/Plugins/datatables/jquery.dataTables.min.css",
                      "~/Plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"
                      ));

        }
    }
}
