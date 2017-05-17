using App.Marriage.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.DAL
{
    public class EnumDAL
    {

        #region Properties

        private SOKNAEntities Db;
        private Enums _Enums;
        public Enums Enumss
        {
            get { return _Enums; }
            set { _Enums = value; }
        }


        #endregion

        #region Construction Functions

        public EnumDAL()
        {
            _Enums = new Enums();
        }

        public EnumDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Enums = Db.Enums.Single(r => r.Id == Id);
        }

        public EnumDAL(Enums Pa)
        {
            _Enums = Pa;
        }


        #endregion
        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Enums.Add(_Enums);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Enums.Remove(_Enums);
            Db.SaveChanges();
        }
        #endregion



        #region Business Function
        public static List<EnumDAL> GetEnumsList()
        {
            List<EnumDAL> List = new List<EnumDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Enums.ToList();
                Res.ForEach(r => List.Add(new EnumDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetEnumsComboList(string EnumType)
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Enums.Where(r=>r.EnumKey == EnumType).Select(r => new { Name = r.NameL1, Id = r.EnumValue }).ToList().OrderBy(e => e.Id);
                return Res;
            }

        }
        #endregion
    }
}