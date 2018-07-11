using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestorauntManagment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "RestaurantManagement-HomePage";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeCulture(string lang)
        {
            var langCookie = new HttpCookie("lang", lang)
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMonths(100)
            };

            Response.AppendCookie(langCookie);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}