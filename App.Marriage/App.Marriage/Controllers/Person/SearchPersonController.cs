using DevExpress.Web.Mvc;
using App.Marriage.DAL;
using App.Marriage.Models.PersonMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        }

        [ValidateInput(false)]
        public ActionResult PersonGVP()
        {
            var model = PersonViewModel.GetPersonList();
            return PartialView("~/Views/SearchPerson/_PersonGVP.cshtml", model);
        }

        [ValidateInput(false)]
        public ActionResult PersonPVG()
        {
            var model = PersonViewModel.GetPersonList();
            return PartialView("~/Views/SearchPerson/_PersonPVG.cshtml", model);
        }

        public ActionResult GetPerson(string Country, int Ages, string Education, string Nationality, string Gender)
        {
            var model = PersonViewModel.GetPersonList();

            return Json(model);
        }
    
    }
}