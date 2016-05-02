using System.Web.Optimization;

namespace SimpleBlogB
{
    public class BundleConfig
    {
        public static void RegisterBundes(BundleCollection bundles)
        {
            // Styles
            bundles.Add(new StyleBundle("~/admin/styles")
                .Include("~/content/styles/bootstrap.css")
                .Include("~/content/styles/admin.css"));

            bundles.Add(new StyleBundle("~/styles")
                .Include("~/content/styles/bootstrap.css")
                .Include("~/content/styles/site.css"));

            // Scripts
            bundles.Add(new ScriptBundle("~/admin/scripts")
                .Include("~/scripts/jquery-2.2.3.js")
                .Include("~/scripts/jquery.validate.js")
                .Include("~/scripts/jquery.validate.unobtrusive.js")
                .Include("~/scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/scripts")
                .Include("~/scripts/jquery-2.2.3.js")
                .Include("~/scripts/jquery.validate.js")
                .Include("~/scripts/jquery.validate.unobtrusive.js")
                .Include("~/scripts/bootstrap.js"));
        }
    }
}