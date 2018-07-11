using NLog;
using RestorauntManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RestorauntManagment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info("Application_Start");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            logger.Info("Application_End");
        }

        protected void Application_BeginRequest()
        {
            logger.Info("Application_BeginRequest");
        }

        protected void Application_EndRequest()
        {
            logger.Info("Application_EndRequest");
        }

        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    var handler = Context.Handler as MvcHandler;
        //    var routeData = handler != null ? handler.RequestContext.RouteData : null;
        //    // var routeCulture = routeData != null ? routeData.Values["culture"].ToString() : null;
        //    var languageCookie = HttpContext.Current.Request.Cookies["lang"];
        //    var userLanguages = HttpContext.Current.Request.UserLanguages;

        //    // Set the Culture based on a route, a cookie or the browser settings,
        //    // or default value if something went wrong
        //    var cultureInfo = new CultureInfo(languageCookie != null ? languageCookie.Value : "ru");

        //    Thread.CurrentThread.CurrentUICulture = cultureInfo;
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);

        //    var culture = new CultureInfo("en-GB");
        //    Thread.CurrentThread.CurrentCulture.DateTimeFormat = culture.DateTimeFormat;
        //    Thread.CurrentThread.CurrentCulture.NumberFormat = culture.NumberFormat;

        //    switch (Thread.CurrentThread.CurrentCulture.Name)
        //    {
        //        case "en-US":
        //            GlobalVariables.GlobalUserLanguages = "En";
        //            break;
        //        case "ru-RU":
        //            GlobalVariables.GlobalUserLanguages = "Ru";
        //            break;
        //        case "kk-KZ":
        //            GlobalVariables.GlobalUserLanguages = "Kk";
        //            break;
        //        default:
        //            GlobalVariables.GlobalUserLanguages = "";
        //            break;
        //    }
        //}
    }
}
