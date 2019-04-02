using System.Web.Optimization;

namespace IssueTicketingSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

             "~/Scripts/jquery-{version}.js"           
                ));
         


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"
              
                ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
               "~/Content/bootstrap.css"

                ));
            bundles.Add(new ScriptBundle("~/bundles/report").Include(
                "~/Scripts/jquery-confirm/jquery-confirm.js",
                "~/Scripts/jqGrid/i18n/grid.locale-sr.js" ,
                "~/Scripts/jqGrid/jquery.jqGrid.js" ,
                "~/Scripts/jquery-ui.js" ,
                "~/Scripts/jqGrid/jquery.contextmenu.js" ,
                "~/Scripts/datepicker/bootstrap-datepicker.js" ,
                "~/Scripts/datepicker/bootstrap-datepicker.sr.min.js" ,
                "~/Scripts/bootstrap3-typeahead.js" ,
                "~/Scripts/jqGridDefaults.js" ,
                "~/Scripts/JqGridHeplers.js"
                    ));
        }
    }
}
