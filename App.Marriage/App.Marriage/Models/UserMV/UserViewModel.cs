using App.Marriage.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Models.UserMV
{
    public class UserViewModel
    {
        #region Properties
        private int _Id;
        private string _UserName;
        private string _Password;
        private bool? _IsActive;
        private string _Usertype;
        private int? _RoleID;
        
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        } 
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public bool? IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public string UserType
        {
            get { return _Usertype; }
            set { _Usertype = value; }
        }
        public int? RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        #endregion

        #region Constractors
        public UserViewModel(UserDAL U) 
        {
            _Id = U.Users.Id;
            _UserName = U.Users.UserName;
            _Password = U.Users.UserPassword;
            _IsActive = U.Users.IsActive;
            _Usertype = U.Users.UserType;
            _RoleID = U.Users.Role_Id;
        }

        public UserViewModel(int id, string userName, string password, bool? isActive, string userType, int roleID)
        {
            _Id = id;
            _UserName = userName;
            _Password = password;
            _IsActive = IsActive;
            _Usertype = userType;
            _RoleID = roleID;
        }

        public UserViewModel(int id)
        {
            _Id = id;
        }
        public UserViewModel()
        {
            
        }
        #endregion

        #region Operations
        public void Create()
        {
            UserDAL U = new UserDAL();
            U.Users.Id = _Id;
            U.Users.UserName = _UserName;
            U.Users.UserPassword = _Password;
            U.Users.IsActive = (bool)_IsActive;
            U.Users.UserType = _Usertype;
            U.Users.Role_Id = _RoleID;

            U.Create();

            _Id = U.Users.Id;
        }

        public void Update()
        {
            UserDAL U = new UserDAL(_Id);
            if (!string.IsNullOrEmpty(_UserName))
                U.Users.UserName = _UserName;

            if (!string.IsNullOrEmpty(_Password))
                U.Users.UserPassword = _Password;

            if (!string.IsNullOrEmpty(_Usertype))
                U.Users.UserType = _Usertype;

            if (_IsActive != null)
                U.Users.IsActive = (bool)_IsActive;

            if (_RoleID != 0 && _RoleID !=null)
                U.Users.Role_Id = _RoleID;

            U.Update();

        }

        public void Delete()
        {
            UserDAL U = new UserDAL(_Id);
            U.Delete();
        }

        #endregion

        #region Busniss Func
        public static List<UserViewModel> GetUserList()
        {
            List<UserViewModel> UList = new List<UserViewModel>();
            UserDAL.GetUsersList().ForEach(u => UList.Add(new UserViewModel(u)));
            return UList;
        }
        public static IEnumerable GetUserComboList()
        {
            return UserDAL.GetUsersComboList();
        }
        #endregion
    }
}