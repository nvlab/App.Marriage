using DevExpress.Web.Mvc;
using App.Marriage.DAL;
using App.Marriage.Models.PersonMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Utils;

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
    
    }
}