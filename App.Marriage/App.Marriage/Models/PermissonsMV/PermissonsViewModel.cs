using App.Marriage.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Models.PermissonsMV
{
    public class PermissonsViewModel
    {
        #region properties
        private int _Id;
        private string _NameL1;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string NameL1
        {
            get { return _NameL1; }
            set { _NameL1 = value; }
        }
        #endregion

        #region Constractors
        public PermissonsViewModel(PermissonsDAL R)
        {
            _Id = R.Permissons.Id;
            _NameL1 = R.Permissons.NameL1;
        }

        public PermissonsViewModel(int Id, string NameL1)
        {
            _Id = Id;
            _NameL1 = NameL1;
        }

        public PermissonsViewModel(int Id)
        {
            _Id = Id;
        }
        #endregion

        #region Operations
        public void Create()
        {
            PermissonsDAL R = new PermissonsDAL();
            R.Permissons.Id = _Id;
            R.Permissons.NameL1 = _NameL1;

            R.Create();

            _Id = R.Permissons.Id;

        }

        public void Update()
        {
            PermissonsDAL R = new PermissonsDAL();

            if (!string.IsNullOrEmpty(_NameL1))
                R.Permissons.NameL1 = _NameL1;
            
        }

        public void Delete()
        {
            PermissonsDAL R = new PermissonsDAL(_Id);
            R.Delete();
        }
        #endregion

        #region Nuseiess Functions
        public static List<PermissonsViewModel> GetPermissonsList()
        {
            List<PermissonsViewModel> RList = new List<PermissonsViewModel>();
            PermissonsDAL.GetPermissonsList().ForEach(r => RList.Add(new PermissonsViewModel(r)));
            return RList;
        }

        public static IEnumerable GetPermissonsComboList()
        {
            return PermissonsDAL.GetPermissonsComboList();

        }
        #endregion
    }
}