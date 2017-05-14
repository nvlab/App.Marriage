using App.Marriage.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.DAL
{
    public class NationalityDAL
    {

        #region Properties

        private SOKNAEntities Db;
        private Nationality _Nationality;
        public Nationality Nationalitys
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }


        #endregion

        #region Construction Functions

        public NationalityDAL()
        {
            _Nationality = new Nationality();
        }

        public NationalityDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Nationality = Db.Nationality.Single(r => r.Id == Id);
        }

        public NationalityDAL(Nationality Pa)
        {
            _Nationality = Pa;
        }


        #endregion
        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Nationality.Add(_Nationality);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Nationality.Remove(_Nationality);
            Db.SaveChanges();
        }
        #endregion



        #region Business Function
        public static List<NationalityDAL> GetNationalitysssList()
        {
            List<NationalityDAL> List = new List<NationalityDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Nationality.ToList();
                Res.ForEach(r => List.Add(new NationalityDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetNationalitysComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Nationality.Select(r => new { Name = r.NameL1, Id = r.Id }).ToList().OrderBy(r => r.Name);
                return Res;
            }

        }
        #endregion
    }
}