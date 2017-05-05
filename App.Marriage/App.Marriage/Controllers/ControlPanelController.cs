using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Controllers
{
    public class ControlPanelController : BaseController
    {
        // GET: ControlPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}