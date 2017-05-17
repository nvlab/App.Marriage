using App.Marriage.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.DAL
{
    public class PersonDAL
    {
        #region Properties

        private SOKNAEntities Db;
        private Person _Persons;
        public Person Persons
        {
            get { return _Persons; }
            set { _Persons = value; }
        }


        #endregion

        #region Construction Functions

        public PersonDAL()
        {
            _Persons = new Person();
        }

        public PersonDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Persons = Db.Person.Single(r => r.Id == Id);
        }

        public PersonDAL(Person Pa)
        {
            _Persons = Pa;
        }


        #endregion
        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Person.Add(_Persons);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Person.Remove(_Persons);
            Db.SaveChanges();
        }
        #endregion



        #region Business Function
        public static List<PersonDAL> GetPersonsList()
        {
            List<PersonDAL> List = new List<PersonDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Person.ToList();
                Res.ForEach(r => List.Add(new PersonDAL(r)));

            }
            return List;
        }

        public static List<PersonDAL> GetPersonsList(int Country, int Ages, string Education, int Nationality, string Gender)
        {
            List<PersonDAL> List = new List<PersonDAL>();
            using (var db = new SOKNAEntities())
            {
                bool IsEductionEnable = string.IsNullOrEmpty(Education);
                bool IsGenederEnable = string.IsNullOrEmpty(Gender);
                var Res = db.Person.Where(r =>
               (r.Residence_Country_Id == Country || Country == 0) &&
               (r.Nationality_Id == Country || Nationality == 0) &&
               (r.Age == Ages || Ages == 0) &&
               (IsEductionEnable || r.Education == Education) &&
               (IsGenederEnable || r.Gender == Gender) 
                ).ToList();
                Res.ForEach(r => List.Add(new PersonDAL(r)));

            }
            return List;
        }

        public static PersonDAL GetPersonPhotoByUserId(int? senderUser_Id)
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Person.First(r=>r.User_Id ==senderUser_Id);
                return new PersonDAL(Res.Id);
            }
        }

        public static IEnumerable GetPersonsComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Person.Select(r => new { Name = r.FullName, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion
    }
}