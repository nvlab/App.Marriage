using App.Marriage.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Models.RoleMV
{
    public class RoleViewModel
    {
        #region properties
        private int _Id;
        private string _RoleName;
        private string _Description;
        private string _RoleState;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string RoleDtate
        {
            get { return _RoleState; }
            set { _RoleState = value; }
        }
        #endregion

        #region Constractors
        public RoleViewModel(RolesDAL R)
        {
            _Id = R.Roles.Id;
            _RoleName = R.Roles.RoleName;
            _Description = R.Roles.Description;
            _RoleState = R.Roles.RoleStatus;
        }

        public RoleViewModel(int Id, string RoleName, string Desc, string RoleState)
        {
            _Id = Id;
            _RoleName = RoleName;
            _Description = Desc;
            _RoleState = RoleState;
        }

        public RoleViewModel(int Id)
        {
            _Id = Id;
        }
        #endregion

        #region Operations
        public void Create()
        {
            RolesDAL R = new RolesDAL();
            R.Roles.Id = _Id;
            R.Roles.RoleName = _RoleName;
            R.Roles.Description = _Description;
            R.Roles.RoleStatus = _RoleState;

            R.Create();

            _Id = R.Roles.Id;

        }

        public void Update()
        {
            RolesDAL R = new RolesDAL();

            if (!string.IsNullOrEmpty(_RoleName))
                R.Roles.RoleName = _RoleName;

            if (!string.IsNullOrEmpty(_Description))
                R.Roles.Description = _Description;

            if (!string.IsNullOrEmpty(_RoleState))
                R.Roles.RoleStatus = _RoleState;
        }

        public void Delete()
        {
            RolesDAL R = new RolesDAL(_Id);
            R.Delete();
        }
        #endregion

        #region Nuseiess Functions
        public static List<RoleViewModel> GetRoleList()
        {
            List<RoleViewModel> RList = new List<RoleViewModel>();
            RolesDAL.GetRolesList().ForEach(r => RList.Add(new RoleViewModel(r)));
            return RList;
        }

        public IEnumerable GetRoleComboList()
        {
            return RolesDAL.GetRolesComboList();

        }
        #endregion
    }
}