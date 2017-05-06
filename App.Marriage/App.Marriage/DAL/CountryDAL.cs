using App.Marriage.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.DAL
{
    public class CountryDAL
    {
        #region Properties

        private SOKNAEntities Db;
        private Country _Countrys;
        public Country Countrys
        {
            get { return _Countrys; }
            set { _Countrys = value; }
        }


        #endregion

        #region Construction Functions

        public CountryDAL()
        {
            _Countrys = new Country();
        }

        public CountryDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Countrys = Db.Country.Single(r => r.Id == Id);
        }

        public CountryDAL(Country Pa)
        {
            _Countrys = Pa;
        }


        #endregion
        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Country.Add(_Countrys);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Country.Remove(_Countrys);
            Db.SaveChanges();
        }
        #endregion



        #region Business Function
        public static List<CountryDAL> GetCountrysssList()
        {
            List<CountryDAL> List = new List<CountryDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Country.ToList();
                Res.ForEach(r => List.Add(new CountryDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetCountrysComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Country.Select(r => new { Name = r.NameL1, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion
    }
}