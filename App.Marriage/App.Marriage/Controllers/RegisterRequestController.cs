using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Models.RegisterRequesMV;
using App.Marriage.Models.PersonMV;
using App.Marriage.DAL;
using App.Marriage.Helpars;
using App.Marriage.Models.RequestQuestionSenarioMV;
using App.Marriage.Models.QuestionMV;
using System.Threading.Tasks;

namespace App.Marriage.Controllers
{
    public class RegisterRequestController : Controller
    {
        // GET: RegisterRequest
        public ActionResult Index()
        {
            if (!UserHelpar.CanDo(Permissons.AcceptUser))
                return RedirectToAction("Unauthorized", "Home", null);
            return View();
        }
        #region RR
        [ValidateInput(false)]
        public ActionResult RegisterRequestGVP()
        {
            var model = RegisterRequestViewModels.Get_RegisterRequestsList();
            return PartialView("_RegisterRequestGVP", model);
        }
        public async Task<ActionResult> SendQuestions(int Id)
        {

            RegisterRequestsDAL rrDAL = new RegisterRequestsDAL(Id);
            rrDAL.RegisterRequests.RequestStatus = 1;
            rrDAL.Update();
            var Email = rrDAL.RegisterRequests.Person.Email;
            var Subject = "الاسئلة - موقع سكنا";
            var Message = "اضغط هنا للاجابة على الاسئلة";

            Message = "<a href=\"sokna.org\\RegisterRequests\\QA\\"+rrDAL.RegisterRequests.Id+" \">";

            MailHelpar emailService = new MailHelpar();
            //await emailService.SendEmailAsync(Email, Message, Subject);

            return Json(new { error = false ,data = "تم الارسال بنجاح"}, JsonRequestBehavior.AllowGet);
            //return Json(new { error = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QA(int Id)
        {
            var model = new List<RequestQuestionSenarioViewModel>();
            if (Id != 0)
                model = RequestQuestionSenarioViewModel.GetRequestQuestionSenarioListByRegisterRequests_Id(Id);

            ViewBag.Id = Id;
            RegisterRequestsDAL RR = new RegisterRequestsDAL(Id);

            ViewBag.Status = RR.RegisterRequests.RequestStatus.GetValueOrDefault();

            ViewBag.QA = model;
            ViewBag.ReturnUrl = "RegisterRequest/QA/" + Id;
            return View();
        }

        [HttpPost]
        public ActionResult QA()
        {
            int Id = int.Parse(Request.Params["Id"]);
            var model = new List<RequestQuestionSenarioViewModel>();
            if (Id != 0)
                model = RequestQuestionSenarioViewModel.GetRequestQuestionSenarioListByRegisterRequests_Id(Id);
            foreach(var Q in model)
            {
                var Answers = Request.Params["Answers_"+Q.Id];
                RequestQuestionSenarioDAL RQS = new RequestQuestionSenarioDAL(Q.Id);
                RQS.RequestQuestionSenario.Answers = Answers;
                RQS.Update();
            }
            RegisterRequestsDAL rrDAL = new RegisterRequestsDAL(Id);
            rrDAL.RegisterRequests.RequestStatus = 2;
            rrDAL.Update();
            ViewBag.ReturnUrl = "RegisterRequest/QA/"+ Id;
            return View();
        }
        [HttpPost]
        public ActionResult AcceptApplication(int Id)
        {
            RegisterRequestsDAL rrDAL = new RegisterRequestsDAL(Id);
            rrDAL.RegisterRequests.RequestStatus = 3;
            rrDAL.Update();
            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RejecteApplication(int Id)
        {
            RegisterRequestsDAL rrDAL = new RegisterRequestsDAL(Id);
            rrDAL.RegisterRequests.RequestStatus = 4;
            rrDAL.Update();
            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region RR detail
        // GET: RegisterRequest
        public ActionResult Detail(int Id)
        {
            RegisterRequestsDAL rrDAL = new RegisterRequestsDAL(Id);
            RegisterRequestViewModels RR = new RegisterRequestViewModels(rrDAL.RegisterRequests);
            PersonDAL PDAL = new PersonDAL(rrDAL.RegisterRequests.Person_Id.Value);
            PersonViewModel P = new PersonViewModel(PDAL);
            ViewBag.Id = Id;
            ViewBag.Status = RR.RequestStatus.GetValueOrDefault();
            ViewBag.RR = RR;
            ViewBag.P = P;
            return View();
        }
        #endregion

        #region RequestQuestionGVP

        [ValidateInput(false)]
        public ActionResult QuestionBankGVP()
        {
            var model = QuestionBankViewModel.GetQuestionBankList();
            return PartialView("_QuestionBankGVP", model);
        }

        [ValidateInput(false)]
        public ActionResult RequestQuestionGVP(int Id)
        {
            var model = new List<RequestQuestionSenarioViewModel>();
            if (Id != 0)
                model = RequestQuestionSenarioViewModel.GetRequestQuestionSenarioListByRegisterRequests_Id(Id);
            ViewBag.Id = Id;
            RegisterRequestsDAL RR = new RegisterRequestsDAL(Id);
            ViewBag.Status = RR.RegisterRequests.RequestStatus.GetValueOrDefault();

            return PartialView("_RequestQuestionGVP", model);
        }
        
        [HttpPost, ValidateInput(false)]
        public ActionResult RequestQuestionGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] MVCxGridViewBatchUpdateValues<RequestQuestionSenarioViewModel, int> updateValues,int Id)
        {
            ViewBag.Id = Id;
            RegisterRequestsDAL RR = new RegisterRequestsDAL(Id);
            ViewBag.Status = RR.RegisterRequests.RequestStatus.GetValueOrDefault();

            var model = RequestQuestionSenarioViewModel.GetRequestQuestionSenarioListByRegisterRequests_Id(Id);
            // Insert all added values. 
            var newId = model.Count > 0 ? model.Max(i => i.Id) : 0;
            foreach (var item in updateValues.Insert)
            {
                try
                {
                    RequestQuestionSenarioViewModel RQS = new RequestQuestionSenarioViewModel();
                    RQS.Question_id = item.Question_id;
                    RQS.RegisterRequests_Id = Id;
                    RQS.Create();
                    model.Add(RQS);
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(item, e.Message);
                }
            }
            // Update all edited values. 
            foreach (var item in updateValues.Update)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        item.Update();
                    }
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(item, e.Message);
                }
            }
            // Delete all values that were deleted on the client side from the data source. 
            foreach (var ItemID in updateValues.DeleteKeys)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Convert.ToInt32(ItemID));
                    if (item != null) item.Delete();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemID, e.Message);
                }
            }
            
            return PartialView("_RequestQuestionGVP", model);
        }
        #endregion
    }
}