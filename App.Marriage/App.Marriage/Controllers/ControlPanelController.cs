using App.Marriage.Helpars;
using App.Marriage.DAL;
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
            if (UserHelpar.GetUserType() != "Admin")
                return RedirectToAction("Unauthorized", "Home", null);

            var persons = PersonDAL.GetPersonsList();
            ViewBag.PersonCount = persons.Count;

            var RegisterRequest = RegisterRequestsDAL.Get_RegisterRequestsList();
            ViewBag.RegisterRequestCount = RegisterRequest.Count;

            var RelationRequest = RelationRequestDAL.GetRelationRequestList();
            ViewBag.RelationRequestCount = RelationRequest.Count;

            return View();
        }
    }
}