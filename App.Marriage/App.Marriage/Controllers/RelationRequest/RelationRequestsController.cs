using App.Marriage.Models.RelationRequestMV;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Controllers.RelationRequest
{
    public class RelationRequestsController : Controller
    {

        private string RquestRelationView = "~/Views/RelationRequests/_RequestRelationGVP.cshtml";
        // GET: RelationRequests
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult RequestRelationGVP()
        {
            var model = RelationRequestViewModel.GetRelationRequestList();
            return PartialView(RquestRelationView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RequestRelationGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]  RelationRequestViewModel RelationRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new RelationRequest in your model
                    RelationRequest.Create();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = RelationRequest.GetModelStateError(ModelState);
            var model = RelationRequestViewModel.GetRelationRequestList();
            return PartialView(RquestRelationView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RequestRelationGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]  RelationRequestViewModel RelationRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the RelationRequest in your model
                    RelationRequest.Update();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = RelationRequest.GetModelStateError(ModelState);
            var model = RelationRequestViewModel.GetRelationRequestList();
            return PartialView(RquestRelationView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RequestRelationGVPDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the RelationRequest from your model
                    var RequestRelation = RelationRequestViewModel.Find(Id);
                    RequestRelation.Delete();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = RelationRequestViewModel.GetRelationRequestList();
            return PartialView(RquestRelationView, model);
        }
    }
}