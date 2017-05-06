using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.DAL;
using System.Collections;

namespace App.Marriage.Models.CategoryMV
{
    public class CategoryViewModel
    {
        #region Properties
        private int _Id;
        private string _CatName;
        private int? _EntityOrder;
        private string _CatType;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string CatName
        {
            get { return _CatName; }
            set { _CatName = value; }
        }

        public int? EntityOrder
        {
            get { return _EntityOrder; }
            set { _EntityOrder = value; }
        }

        public string CatType
        {
            get { return _CatType; }
            set { _CatType = value; }
        }
        #endregion

        #region Constractors
        public CategoryViewModel(CategoryDAL Cat)
        {
            _Id = Cat.Categories.Id;
            _CatName = Cat.Categories.Category1;
            _EntityOrder = Cat.Categories.Entity_Order;
            _CatType = Cat.Categories.CatType;
            
        }

        public CategoryViewModel(int Id, string CatName, string CatType, int EntityOrder)
        {
            _Id = Id;
            _CatName = CatName;
            _CatType = CatType;
            _EntityOrder = EntityOrder;
        }
        public CategoryViewModel(int id)
        {
            _Id = id;
        }
        #endregion

        #region Operations
        public void Create()
        {
            CategoryDAL Cat = new CategoryDAL();
            Cat.Categories.Id = _Id;
            Cat.Categories.Category1 = _CatName;
            Cat.Categories.Entity_Order = _EntityOrder;
            Cat.Categories.CatType = _CatType;

            Cat.Create();

            _Id = Cat.Categories.Id;
        }

        public void Update()
        {
            CategoryDAL Cat = new CategoryDAL(_Id);

            if (!string.IsNullOrEmpty(_CatName))
                Cat.Categories.Category1 = _CatName;

            if (!string.IsNullOrEmpty(_CatType))
                Cat.Categories.CatType = _CatType;

            if (_EntityOrder != null)
                Cat.Categories.Entity_Order = _EntityOrder;

            Cat.Update();

        }
        public void Delete()
        {
            CategoryDAL Cat = new CategoryDAL(_Id);
            Cat.Delete();
        }
        #endregion

        #region Busniss Func
        public static List<CategoryViewModel> GetUserList()
        {
            List<CategoryViewModel> CList = new List<CategoryViewModel>();
            CategoryDAL.GetCategoriesList().ForEach(c => CList.Add(new CategoryViewModel(c)));
            return CList;
        }
        public static IEnumerable GetUserComboList()
        {
            return CategoryDAL.GetCategoriesComboList();
        }
        #endregion
    }
}