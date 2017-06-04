using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class PermissonsDAL
    {
        #region Properties
        SOKNAEntities Db;
        private Permissons _Permissons;
        public Permissons Permissons
        {
            get { return _Permissons; }
            set { _Permissons = value; }
        }
        #endregion

        #region Construction Functions

        public PermissonsDAL()
        {
            _Permissons = new Permissons();
        }

        public PermissonsDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Permissons = Db.Permissons.Single(r => r.Id == Id);
        }

        public PermissonsDAL(Permissons Ra)
        {
            _Permissons = Ra;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Permissons.Add(_Permissons);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Permissons.Remove(_Permissons);
            Db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<PermissonsDAL> GetPermissonsList()
        {
            List<PermissonsDAL> List = new List<PermissonsDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Permissons.ToList();
                Res.ForEach(r => List.Add(new PermissonsDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetPermissonsComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Permissons.Select(r => new { Name = r.NameL1, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion

    }
}