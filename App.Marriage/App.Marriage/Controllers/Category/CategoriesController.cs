using App.Marriage.Models.CategoryMV;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Controllers.Category
{
    public class CategoriesController : Controller
    {

        private string CategoryView = "~/Views/Categories/_CategoryGVP.cshtml";
        // GET: Categorys
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CategoryGVP()
        {
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CategoryView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CategoryGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]  CategoryViewModel Category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new Category in your model
                    Category.Create();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = Category.GetModelStateError(ModelState);
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CategoryView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CategoryGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]  CategoryViewModel Category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the Category in your model
                    Category.Update();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = Category.GetModelStateError(ModelState);
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CategoryView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CategoryGVPDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the Category from your model
                    var Category = CategoryViewModel.Find(Id);
                    Category.Delete();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = CategoryViewModel.GetCategoryList();
            return PartialView(CategoryView, model);
        }
    }
}