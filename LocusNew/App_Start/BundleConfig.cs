using System.Web;
using System.Web.Optimization;

namespace LocusNew
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //ADMIN BUNDLES

            //SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/AdminScripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/bootstrap.js",
                        "~/Areas/Admin/Content/js/pikeadmin.js",
                        "~/Areas/Admin/Content/js/moment.min.js",
                        "~/Areas/Admin/Content/js/detect.js",
                        "~/Areas/Admin/Content/js/fastclick.js",
                        "~/Areas/Admin/Content/js/jquery.blockUI.js",
                        "~/Areas/Admin/Content/js/jquery.nicescroll.js",
                        "~/Areas/Admin/Content/js/switchery.min.js",
                        "~/Scripts/summernote/summernote.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                        "~/Scripts/datepicker-bs.js",
                        "~/Scripts/toastr.js",
                        "~/Areas/Admin/Content/js/dataTables.js",
                        "~/Areas/Admin/Content/js/dataTablesBootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapScript").Include(
                        "~/Areas/Admin/Content/js/ListingAddMap.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTableInit").Include(
                        "~/Areas/Admin/Content/js/datatableInit.js"));

            bundles.Add(new ScriptBundle("~/bundles/Select2js").Include(
                       "~/Areas/Admin/Content/js/select2.js",
                       "~/Areas/Admin/Content/js/select2-init.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/ListingJS").Include(
                        "~/Areas/Admin/Content/js/listing.js"));

            bundles.Add(new ScriptBundle("~/bundles/editListingJS").Include(
                        "~/Areas/Admin/Content/js/editListing.js"));

            bundles.Add(new ScriptBundle("~/bundles/addListingJS").Include(
                        "~/Areas/Admin/Content/js/addListing.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboardJS").Include(
                       "~/Areas/Admin/Content/js/chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalSettingsJs").Include(
                        "~/Areas/Admin/Content/js/globalSettings.js"));

            bundles.Add(new ScriptBundle("~/bundles/searchAdminListings").Include(
                        "~/Areas/Admin/Content/js/searchAdminListings.js"));

            //CSS
            bundles.Add(new StyleBundle("~/Content/admin/select2Css").Include(
                       "~/Areas/Admin/Content/css/select2.css"));

            bundles.Add(new StyleBundle("~/Content/AdminCSS").Include(
                        "~/Content/bootstrap.css",
                        "~/Areas/Admin/Content/css/switchery.css",
                        "~/Content/themes/base/jquery-ui.css",
                        "~/Areas/Admin/Content/css/style.css",
                        "~/Scripts/summernote/summernote.css",
                        "~/Content/toastr.css",
                        "~/Areas/Admin/Content/css/dataTables.css").Include(
                        "~/Content/font-awesome.css", new CssRewriteUrlTransform()));


            //USER BUNDLES

            //SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/userApp").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/customScripts/Scripts.js",
                        "~/Scripts/customScripts/googleJs.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlJS").Include(
                        "~/Scripts/OwlCarousel2.js"));

            bundles.Add(new ScriptBundle("~/bundles/homeScript").Include(
                        "~/Scripts/customScripts/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/searchScript").Include(
                        "~/Scripts/customScripts/search.js"));

            bundles.Add(new ScriptBundle("~/bundles/single-listingScript").Include(
                        "~/Scripts/customScripts/listing.js"));

            bundles.Add(new ScriptBundle("~/bundles/sell-repurchaceScript").Include(
                        "~/Scripts/customScripts/sell-repurchace.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquiJS").Include(
                        "~/Scripts/jquery-ui-1.12.1.js",
                        "~/Scripts/datepicker-bs.js"));

            bundles.Add(new ScriptBundle("~/bundles/lightboxJS").Include(
                        "~/Scripts/lightbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/innerScripts").Include(
                        "~/Scripts/customScripts/innerScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/mapSearch").Include(
                        "~/Scripts/customScripts/mapSearch.js"));

            //CSS
            bundles.Add(new StyleBundle("~/Content/UserCSS").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/style.css").Include(
                       "~/Content/font-awesome5.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/UserCSSInner").Include(
                        "~/Content/inner.css"));

            bundles.Add(new StyleBundle("~/Content/lightBoxCss").Include(
                       "~/Content/lightbox.css"));

            bundles.Add(new StyleBundle("~/Content/owlCSS").Include(
                        "~/Content/owl-carousel.css",
                        "~/Content/owl-theme.css"));

            bundles.Add(new StyleBundle("~/Content/datepickerCss").Include(
                        "~/Content/themes/base/jquery-ui.css",
                        "~/Content/themes/base/datepicker.css"));

            bundles.Add(new StyleBundle("~/Content/mapSearchCss").Include(
                        "~/Content/mapSearch.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}