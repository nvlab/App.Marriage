using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

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
        public static List<PersonDAL> GetPersonsssList()
        {
            List<PersonDAL> List = new List<PersonDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Person.ToList();
                Res.ForEach(r => List.Add(new PersonDAL(r)));

            }
            return List;
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