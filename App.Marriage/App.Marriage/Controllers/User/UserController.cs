using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Models.UserMV;

namespace App.Marriage.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserViewModel> model = UserViewModel.GetUserList();
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult UserGVP()
        {
            var model = new object[0];
            return PartialView("~/Views/User/_UserGVP.cshtml", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UserGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.UserMV.UserViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/User/_UserGVP.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.UserMV.UserViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/User/_UserGVP.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserGVPDelete(System.Int32 Id)
        {
            var model = new object[0];
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("~/Views/User/_UserGVP.cshtml", model);
        }
    }
}