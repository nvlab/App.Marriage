using App.Marriage.Models.CategoryMV;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Controllers.Category
{
    public class CategoryController : Controller
    {
        // GET: Category
        string CatPV = "~/Views/Category/_CategoryGVP.cshtml";
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CategoryGVP()
        {
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CatPV, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CategoryGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.CategoryMV.CategoryViewModel cat)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    cat.Create();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CatPV, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CategoryGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.CategoryMV.CategoryViewModel cat)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    cat.Update();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CatPV, model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CategoryGVPDelete(System.Int32 Id)
        {
           
            if (Id >= 0)
            {
                try
                {
                    CategoryViewModel cat = new CategoryViewModel(Id);
                    cat.Delete();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CatPV, model);
        }
    }
}