using App.Marriage.Models.QuestionMV;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Controllers.QuestionBanks
{
    public class QuestionBankController : Controller
    {

        private string QuestionBankView = "~/Views/QuestionBank/_QuestionBankGVP.cshtml";
        // GET: QuestionBanks
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult QuestionBankGVP()
        {
            var model = QuestionBankViewModel.GetQuestionBankList();
            return PartialView(QuestionBankView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuestionBankGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]  QuestionBankViewModel QuestionBank)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new QuestionBank in your model
                    QuestionBank.Create();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = QuestionBank.GetModelStateError(ModelState);
            var model = QuestionBankViewModel.GetQuestionBankList();
            return PartialView(QuestionBankView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuestionBankGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]  QuestionBankViewModel QuestionBank)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the QuestionBank in your model
                    QuestionBank.Update();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = QuestionBank.GetModelStateError(ModelState);
            var model = QuestionBankViewModel.GetQuestionBankList();
            return PartialView(QuestionBankView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult QuestionBankGVPDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the QuestionBank from your model
                    var QuestionBank = QuestionBankViewModel.Find(Id);
                    QuestionBank.Delete();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = QuestionBankViewModel.GetQuestionBankList();
            return PartialView(QuestionBankView, model);
        }
    }
}