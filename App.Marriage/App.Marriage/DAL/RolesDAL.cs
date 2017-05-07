using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class RolesDAL
    {
        #region Properties
        SOKNAEntities Db;
        private Roles _Roles;
        public Roles Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }
        #endregion

        #region Construction Functions

        public RolesDAL()
        {
            _Roles = new Roles();
        }

        public RolesDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Roles = Db.Roles.Single(r => r.Id == Id);
        }

        public RolesDAL(Roles Ra)
        {
            _Roles = Ra;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Roles.Add(_Roles);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Roles.Remove(_Roles);
            Db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<RolesDAL> GetRolesList()
        {
            List<RolesDAL> List = new List<RolesDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Roles.ToList();
                Res.ForEach(r => List.Add(new RolesDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetRolesComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Roles.Select(r => new { Name = r.RoleName, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion

    }
}