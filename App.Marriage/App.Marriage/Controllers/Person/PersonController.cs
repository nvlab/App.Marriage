using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using App.Marriage.Entities;
using App.Marriage.Models.PersonMV;
using App.Marriage.Models.RegisterRequesMV;
using App.Marriage.DAL;

namespace App.Marriage.Controllers.Person
{
    public class PersonController : Controller
    {
        private SOKNAEntities db = new SOKNAEntities();
        private static string genderType;
        private string personPV = "~/Views/Person/_PersonGVP.cshtml";
        // GET: Person
        //public ActionResult Index()
        //{
        //    return View(db.PersonViewModels.ToList());
        //}

        // GET: Person/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PersonViewModel personViewModel = db.PersonViewModels.Find(id);
        //    if (personViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(personViewModel);
        //}

        // GET: Person/Create
        public ActionResult Create(int id)//1 male, 2 female
        {
            

            FeedCombobox(id);

            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nationality_Id,FullName,Father,Mother,Age,BirthDate,Height,Weight,PlaceBirth,Adress,Residence_Country_Id,SocialStatus,Color,Gender,Photo1,Photo2,User_Id,NationalityNumber,PassportNumber,Email,IsActive,Phone1,Phone2,GeneralInfo,NickName,SurName,CountryState,ChildCount,MaxChildAge,MinChildAge,Education,EducationBranch,WorkType,Languages,LivingLevel,Theams,Hobbies,Culture,CultureLevel,Residence_Country,FullName_IsHidden,NickName_IsHidden,SurName_IsHidden,Phone1_IsHidden,Phone2_IsHidden,Email_IsHidden,Adress_IsHidden,Theams_IsHidden,Photo1_IsHidden,Photo2_IsHidden,Color_IsHidden,Weight_IsHidden,Height_IsHidden")] PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                personViewModel.Gender = genderType;
                personViewModel.Create();
                personViewModel.SaveCustomizeFlds();

                // Added BY N
                RegisterRequestViewModels RR = new RegisterRequestViewModels();
                RR.Person_Id = personViewModel.Id;
                RR.RequestStatus = 0;
                RR.RequestDate = DateTime.Now;
                RR.ResponseMessage = 1;
                RR.Create();

                //return RedirectToAction("Index");
                return Content("<script language='javascript' type='text/javascript'>alert('تم حفظ بياناتك');</script>");
            }


            return View(personViewModel);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)//person id
        {
            int gender;
            
            PersonDAL person = new PersonDAL(id);
            if (person.Persons.Gender == "Male")
                gender = 1;
            else
                gender = 2;
            PersonViewModel personViewModel = new PersonViewModel(person);
            if (personViewModel == null)
            {
                return HttpNotFound();
            }
            FeedCombobox(gender);
            return View(personViewModel);
        }
        public ActionResult Profile(int id)
        {
            int gender;
            PersonDAL person = new PersonDAL(id);
            if (person.Persons.Gender == "Male")
                gender = 1;
            else
                gender = 2;
            PersonViewModel personViewModel = new PersonViewModel(person);
            FeedCombobox(gender);
            return View(personViewModel);
        }
        public ActionResult ShowAll()
        {
            return View();
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nationality_Id,FullName,Father,Mother,Age,BirthDate,Height,Weight,PlaceBirth,Adress,Residence_Country_Id,SocialStatus,Color,Gender,Photo1,Photo2,User_Id,NationalityNumber,PassportNumber,Email,IsActive,Phone1,Phone2,GeneralInfo,NickName,SurName,CountryState,ChildCount,MaxChildAge,MinChildAge,Education,EducationBranch,WorkType,Languages,LivingLevel,Theams,Hobbies,Culture,CultureLevel,Residence_Country,FullName_IsHidden,NickName_IsHidden,SurName_IsHidden,Phone1_IsHidden,Phone2_IsHidden,Email_IsHidden,Adress_IsHidden,Theams_IsHidden,Photo1_IsHidden,Photo2_IsHidden,Color_IsHidden,Weight_IsHidden,Height_IsHidden")] PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                personViewModel.Update();
                personViewModel.SaveCustomizeFlds();
                return RedirectToAction("Index");
            }
            //return View("~/Views/Home/Index");
            //return RedirectToAction("Index", "Home");
            //return RedirectToAction("~/Home/Index");
            return Redirect("~/Home/Index");
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FeedCombobox(int personGenderType)
        {
            string socialEnumKey;
            if (personGenderType == 1)
            {
                genderType = "Male";
                socialEnumKey = "SocialStatusM";
            }
               
            else
            {
                genderType = "Female";
                socialEnumKey = "SocialStatusF";
            }
                

            SelectList natList = new SelectList(DAL.NationalityDAL.GetNationalitysComboList(), "Id", "Name");
            SelectList countryList = new SelectList(DAL.CountryDAL.GetCountrysComboList(), "Id", "Name");
            SelectList socialStateList = new SelectList(DAL.EnumDAL.GetEnumsComboList(socialEnumKey), "Id", "Name");
            SelectList educationList = new SelectList(DAL.EnumDAL.GetEnumsComboList("Education"), "Id", "Name");
            SelectList cultureList = new SelectList(DAL.EnumDAL.GetEnumsComboList("Culture"), "Id", "Name");

            ViewData["Gender"] = personGenderType.ToString();
            ViewData["NatCombo"] = natList;
            ViewData["Social"] = socialStateList;
            ViewData["Education"] = educationList;
            ViewData["Din"] = cultureList;
            ViewData["Country"] = countryList;
        }



        [ValidateInput(false)]
        public ActionResult PersonGVP()
        {
            ViewData["Nationality"] = NationalityDAL.GetNationalitysComboList();
            ViewData["Social"] = DAL.EnumDAL.GetEnumsComboList("SocialStatusM");
            ViewData["Gender"] = DAL.EnumDAL.GetEnumsComboList("Gender");
            var model = PersonViewModel.GetPersonList();
            return PartialView(personPV, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult PersonGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.PersonMV.PersonViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Person/_PersonGVP.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PersonGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] App.Marriage.Models.PersonMV.PersonViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("~/Views/Person/_PersonGVP.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult PersonGVPDelete(System.Int32 Id)
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
            return PartialView("~/Views/Person/_PersonGVP.cshtml", model);
        }
    }


}
