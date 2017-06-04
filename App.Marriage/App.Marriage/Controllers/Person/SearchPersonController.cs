using DevExpress.Web.Mvc;
using App.Marriage.DAL;
using App.Marriage.Models.PersonMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Utils;
using App.Marriage.Helpars;
using App.Marriage.Models.RelationRequestMV;
using App.Marriage.Models;

namespace App.Marriage.Controllers.Person
{
    public class SearchPersonController : Controller
    {
        // GET: SearchPerson
        public ActionResult Index()
        {
            GetDataSources();
            return View();
        }

        public void GetDataSources()
        {
            ViewData["Nationality"] = NationalityDAL.GetNationalitysComboList();
            ViewData["Country"] = CountryDAL.GetCountrysComboList();
            ViewData["Education"] = EnumDAL.GetEnumsComboList(EnumType.Education.ToString());
            ViewData["Gender"] = EnumDAL.GetEnumsComboList(EnumType.Geneder.ToString());
        }

       

        public ActionResult GetPerson(int? Country, int? Ages, string Education, int? Nationality, string Gender)
        {
            var model = PersonViewModel.GetPersonList(Country.GetValueOrDefault(),Ages.GetValueOrDefault(), (Education=="null"?null: Education), Nationality.GetValueOrDefault(), (Gender=="null"?null:Gender));

            return Json(model);
        }
    

        public ActionResult RegisterRelationAction(int PersonId)
        {
            var Person = PersonViewModel.Find(PersonId);
            var User = UserHelpar.GetUser();
            if (User.Id!=0)
            {

                var Rel = new RelationRequestViewModel();
                Rel.RequestUser_Id = UserHelpar.GetUserId();
                Rel.TargetUser_Id = Person.User_Id;
                Rel.RequestDate = DateTime.Now;
                Rel.RequestStatus = RelationStatus.Pending.ToString();
                Rel.Create();

              
                return RedirectToAction("Details", "RelationRequests", new { Id = Rel.Id});
            }
            else
            {
               // return RedirectToAction(Url.Action("Login", "Account") +"?returnUrl="+" "+"&relationRequestUserId="+ Person.User_Id);
                return RedirectToAction( "Login", "Account", new {returnUrl = "RelationRequest", relationRequestUserId = Person.User_Id });
            }
        }
    }
}