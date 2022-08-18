using AMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Data.SqlClient;
namespace AMS.Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        string connString = ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //SqlDependency.Start(connString);
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd HH:mm:ss";
            newCulture.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }

        protected void Application_End()
        {
            //Stop SQL dependency
            SqlDependency.Stop(connString);
        }
        //private void LoadCommonSettings()
        //{
        //    //Load Local Resources
        //    string locale = string.IsNullOrEmpty(Convert.ToString(ConfigurationManager.AppSettings["Locale"]))
        //                        ? "en-GB"
        //                        : Convert.ToString(ConfigurationManager.AppSettings["Locale"]);

        //    //Specify the culture for an application
        //    Resources.Culture = CultureInfo.CreateSpecificCulture(locale);
        //    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);

        //    //Bootstrapper.ConfigureUnityContainer();
        //}
        
    }
   
}