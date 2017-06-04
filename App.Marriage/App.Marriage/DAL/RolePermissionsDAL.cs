using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class RolePermissionsDAL
    {
        #region Properties
        SOKNAEntities Db;
        private RolePermissions _RolePermissions;
        public RolePermissions RolePermissions
        {
            get { return _RolePermissions; }
            set { _RolePermissions = value; }
        }
        #endregion

        #region Construction Functions

        public RolePermissionsDAL()
        {
            _RolePermissions = new RolePermissions();
        }

        public RolePermissionsDAL(int Id)
        {
            Db = new SOKNAEntities();
            _RolePermissions = Db.RolePermissions.Single(r => r.Id == Id);
        }
        public RolePermissionsDAL(int Role_Id, int Perm_Id)
        {
            Db = new SOKNAEntities();
            _RolePermissions = Db.RolePermissions.SingleOrDefault(r => r.Roles_Id == Role_Id && r.Permission_Id == Perm_Id);
        }
        public RolePermissionsDAL(RolePermissions Ra)
        {
            _RolePermissions = Ra;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.RolePermissions.Add(_RolePermissions);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.RolePermissions.Remove(_RolePermissions);
            Db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<RolePermissionsDAL> GetRolePermissionsList()
        {
            List<RolePermissionsDAL> List = new List<RolePermissionsDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.RolePermissions.ToList();
                Res.ForEach(r => List.Add(new RolePermissionsDAL(r)));

            }
            return List;
        }
        public static List<RolePermissionsDAL> GetRolePermissionsListByRolId(int Role_Id)
        {
            List<RolePermissionsDAL> List = new List<RolePermissionsDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.RolePermissions.Where(x => x.Roles_Id == Role_Id).ToList();
                Res.ForEach(r => List.Add(new RolePermissionsDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetRolePermissionsComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.RolePermissions.Select(r => new { Name = r.Permissons.NameL1, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion

    }
}