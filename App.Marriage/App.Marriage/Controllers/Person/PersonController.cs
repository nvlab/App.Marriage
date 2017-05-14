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

namespace App.Marriage.Controllers.Person
{
    public class PersonController : Controller
    {
        private SOKNAEntities db = new SOKNAEntities();
        private static string genderType;
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
        public ActionResult Create(string id)//1 male, 2 female
        {
            string socialEnumKey;
            if (id == "1") genderType = "Male"; else genderType = "Female";
            if (id == "1")
                socialEnumKey = "SocialStatusM";
            else
                socialEnumKey = "SocialStatusF";

            SelectList natList = new SelectList(DAL.NationalityDAL.GetNationalitysComboList(),"Id","Name");
            SelectList countryList = new SelectList(DAL.CountryDAL.GetCountrysComboList(), "Id", "Name");
            SelectList socialStateList = new SelectList(DAL.EnumDAL.GetEnumsComboList(socialEnumKey),"Id","Name");
            SelectList educationList = new SelectList(DAL.EnumDAL.GetEnumsComboList("Education"), "Id", "Name");
            SelectList cultureList = new SelectList(DAL.EnumDAL.GetEnumsComboList("Culture"), "Id", "Name");

            ViewData["Gender"] = id;
            ViewData["NatCombo"] = natList;
            ViewData["Social"] = socialStateList;
            ViewData["Education"] = educationList;
            ViewData["Culture"] = cultureList;
            ViewData["Country"] = countryList;

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

                //return RedirectToAction("Index");
                return Content("<script language='javascript' type='text/javascript'>alert('تم حفظ بياناتك');</script>");
            }

            return View(personViewModel);
        }

        // GET: Person/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //PersonViewModel personViewModel = db.PersonViewModels.Find(id);
        //    //if (personViewModel == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(personViewModel);
        //}

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nationality_Id,FullName,Father,Mother,Age,BirthDate,Height,Weight,PlaceBirth,Adress,Residence_Country_Id,SocialStatus,Color,Gender,Photo1,Photo2,User_Id,NationalityNumber,PassportNumber,Email,IsActive,Phone1,Phone2,GeneralInfo,NickName,SurName,CountryState,ChildCount,MaxChildAge,MinChildAge,Education,EducationBranch,WorkType,Languages,LivingLevel,Theams,Hobbies,Culture,CultureLevel,Residence_Country,FullName_IsHidden,NickName_IsHidden,SurName_IsHidden,Phone1_IsHidden,Phone2_IsHidden,Email_IsHidden,Adress_IsHidden,Theams_IsHidden,Photo1_IsHidden,Photo2_IsHidden,Color_IsHidden,Weight_IsHidden,Height_IsHidden")] PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personViewModel);
        }

        // GET: Person/Delete/5
        //public ActionResult Delete(int? id)
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

        // POST: Person/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PersonViewModel personViewModel = db.PersonViewModels.Find(id);
        //    db.PersonViewModels.Remove(personViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

      
    }


}
