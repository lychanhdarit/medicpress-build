using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ASP.App_Start.AjaxHelperBundleConfig), "RegisterBundles")]

namespace ASP.App_Start
{
	public class AjaxHelperBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/ajaxhelper").Include("~/Scripts/jquery.ajaxhelper.js"));
		}
	}
}