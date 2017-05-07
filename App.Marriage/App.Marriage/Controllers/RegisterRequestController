using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Models.RegisterRequesMV;

namespace App.Marriage.Controllers
{
    public class RegisterRequestController : Controller
    {
        // GET: RegisterRequest
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult RegisterRequestGVP()
        {
            var model = RegisterRequestViewModels.Get_RegisterRequestsList();
            return PartialView("_RegisterRequestGVP", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RegisterRequestGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.RegisterRequesMV.RegisterRequestViewModels item)
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
            return PartialView("_RegisterRequestGVP", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RegisterRequestGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.RegisterRequesMV.RegisterRequestViewModels item)
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
            return PartialView("_RegisterRequestGVP", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RegisterRequestGVPDelete(System.Int32 Id)
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
            return PartialView("_RegisterRequestGVP", model);
        }
    }
}