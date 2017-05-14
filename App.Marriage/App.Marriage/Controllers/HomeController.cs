using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["ShowSlider"] = true;
            return View();
        }
        public ActionResult Unauthorized()
        {
            ViewData["ShowSlider"] = false;
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
    }
}