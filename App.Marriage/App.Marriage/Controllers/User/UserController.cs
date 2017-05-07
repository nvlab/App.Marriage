using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Models.UserMV;
using App.Marriage.DAL;

namespace App.Marriage.Controllers
{
    public class UserController : Controller
    {
        private string UserPartial = "~/Views/User/_UserGVP.cshtml";
        // GET: User
        public ActionResult Index()
        {
            List<UserViewModel> model = UserViewModel.GetUserList();
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult UserGVP()
        {
            ViewData["Role"] = RolesDAL.GetRolesComboList();
            var model = UserViewModel.GetUserList();
            return PartialView(UserPartial, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UserGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.UserMV.UserViewModel User)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    User.Create();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var model = UserViewModel.GetUserList();
            return PartialView(UserPartial, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.UserMV.UserViewModel User)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    User.Update();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = UserViewModel.GetUserList();
            return PartialView(UserPartial, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserGVPDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.Int32 Id)
        {
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    var User = new UserViewModel(Id);
                    User.Delete();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = UserViewModel.GetUserList();
            return PartialView(UserPartial, model);
        }
    }
}