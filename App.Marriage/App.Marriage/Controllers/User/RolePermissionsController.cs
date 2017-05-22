using DevExpress.Web.Mvc;
using App.Marriage.Helpars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Models.RoleMV;

namespace App.Marriage.Controllers.User
{
    public class RolePermissionsController : Controller
    {
        // GET: RolePermissions
        public ActionResult Index()
        {
            if (!UserHelpar.CanDo(Permissons.Role))
                return RedirectToAction("Unauthorized", "Home", null);

            return View();
        }

        [ValidateInput(false)]
        public ActionResult RolePermissionsGVP()
        {
            var model = RolePermissionsViewModel.GetRolePermissionsList();
            return PartialView("~/Views/RolePermissions/_RolePermissionsGVP.cshtml", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RolePermissionsGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.RoleMV.RolePermissionsViewModel item)
        {
            var model = new RolePermissionsViewModel();
            //if (ModelState.IsValid)
            //{
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            //}
            //else
            //    ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/RolePermissions/_RolePermissionsGVP.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RolePermissionsGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.RoleMV.RolePermissionsViewModel item)
        {
            
            //if (ModelState.IsValid)
            //{
                try
                {
                    item.Update();
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {

                    ViewData["EditError"] = e.Message;
                }
            //}
            //else
            //    ViewData["EditError"] = "Please, correct all errors.";
            var model = RolePermissionsViewModel.GetRolePermissionsList();
            return PartialView("~/Views/RolePermissions/_RolePermissionsGVP.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RolePermissionsGVPDelete(System.Int32 Id)
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
            return PartialView("~/Views/RolePermissions/_RolePermissionsGVP.cshtml", model);
        }
    }
}