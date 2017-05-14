using App.Marriage.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Models.RoleMV
{
    public class RolePermissionsViewModel
    {
        #region properties
        private int _Id;
        private int _Permission_Id;
        private int _Roles_Id;
        private DateTime _InsertDate;
        private bool _IsActive;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int Permission_Id
        {
            get { return _Permission_Id; }
            set { _Permission_Id = value; }
        }
        public int Roles_Id
        {
            get { return _Roles_Id; }
            set { _Roles_Id = value; }
        }

        public DateTime InsertDate
        {
            get { return _InsertDate; }
            set { _InsertDate = value; }
        }

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        #endregion

        #region Constractors
        public RolePermissionsViewModel(RolePermissionsDAL R)
        {
            _Id = R.RolePermissions.Id;
            _Permission_Id = R.RolePermissions.Permission_Id.GetValueOrDefault();
            _Roles_Id = R.RolePermissions.Roles_Id.GetValueOrDefault();
            _InsertDate = R.RolePermissions.InsertDate.GetValueOrDefault();
            _IsActive = R.RolePermissions.IsActive.GetValueOrDefault();
        }

        public RolePermissionsViewModel(int Id, int Permission_Id, int Roles_Id, DateTime InsertDate,bool IsActive)
        {
            _Id = Id;
            _Permission_Id = Permission_Id;
            _Roles_Id = Roles_Id;
            _InsertDate = InsertDate;
            _IsActive = IsActive;
        }

        public RolePermissionsViewModel(int Id)
        {
            _Id = Id;
        }
        #endregion

        #region Operations
        public void Create()
        {
            RolePermissionsDAL R = new RolePermissionsDAL();
            R.RolePermissions.Id = _Id;
            R.RolePermissions.Permission_Id = _Permission_Id;
            R.RolePermissions.Roles_Id = _Roles_Id;
            R.RolePermissions.InsertDate = _InsertDate;
            R.RolePermissions.IsActive = _IsActive;

            R.Create();

            _Id = R.RolePermissions.Id;

        }

        public void Update()
        {
            RolePermissionsDAL R = new RolePermissionsDAL();

            if (_Permission_Id != null && _Permission_Id != 0)
                R.RolePermissions.Permission_Id = _Permission_Id;

            if (_Roles_Id != null && _Roles_Id != 0)
                R.RolePermissions.Roles_Id = _Roles_Id;

            if (_IsActive != null)
                R.RolePermissions.IsActive = _IsActive;
        }

        public void Delete()
        {
            RolePermissionsDAL R = new RolePermissionsDAL(_Id);
            R.Delete();
        }
        #endregion

        #region Nuseiess Functions
        public static List<RolePermissionsViewModel> GetRoleList()
        {
            List<RolePermissionsViewModel> RList = new List<RolePermissionsViewModel>();
            RolePermissionsDAL.GetRolePermissionsList().ForEach(r => RList.Add(new RolePermissionsViewModel(r)));
            return RList;
        }

        public IEnumerable GetRoleComboList()
        {
            return RolePermissionsDAL.GetRolePermissionsComboList();

        }
        #endregion
    }
}