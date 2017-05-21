using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.DAL;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using App.Marriage.Utils;
using System.Web.Mvc;

namespace App.Marriage.Models.CategoryMV
{
    public class CategoryViewModel : IValidatableObject
    {
        #region Properties
        private int _Id;
        private string _CategoryName;
        private int? _Entity_Order;
        private string _CatType;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        public int? Entity_Order
        {
            get { return _Entity_Order; }
            set { _Entity_Order = value; }
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
            _CategoryName = Cat.Categories.CategoryName;
            _Entity_Order = Cat.Categories.Entity_Order;
            _CatType = Cat.Categories.CatType;
            
        }

        public CategoryViewModel(int Id, string CatName, string CatType, int EntityOrder)
        {
            _Id = Id;
            _CategoryName = CatName;
            _CatType = CatType;
            _Entity_Order = EntityOrder;
        }
        public CategoryViewModel(int id)
        {
            _Id = id;
        }

        public CategoryViewModel()
        {

        }
        #endregion

        #region Operations
        public void Create()
        {
            CategoryDAL Cat = new CategoryDAL();
            Cat.Categories.Id = _Id;
            Cat.Categories.CategoryName = _CategoryName;
            Cat.Categories.Entity_Order = _Entity_Order;
            Cat.Categories.CatType = _CatType;

            Cat.Create();

            _Id = Cat.Categories.Id;
        }

        public void Update()
        {
            CategoryDAL Cat = new CategoryDAL(_Id);

            if (!string.IsNullOrEmpty(_CategoryName))
                Cat.Categories.CategoryName = _CategoryName;

            if (!string.IsNullOrEmpty(_CatType))
                Cat.Categories.CatType = _CatType;

            if (_Entity_Order != null)
                Cat.Categories.Entity_Order = _Entity_Order;

            Cat.Update();

        }
        public void Delete()
        {
            CategoryDAL Cat = new CategoryDAL(_Id);
            Cat.Delete();
        }

        public static CategoryViewModel Find(int Id)
        {
            return new CategoryViewModel(new CategoryDAL(Id));
        }

        #endregion

        #region Busniss Func

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (_NationalNumber.ToString().Length<=NationalLength.IntValue)
            //{
            //yield return new ValidationResult(GlobalLocalized.FieldLength + " " +NationalLength.IntValue, new[] { "NationalNumber" });
            //}

            if (_CategoryName == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "CategoryName" });
            }

            if (_CatType == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "CatType" });
            }
            // return null;
        }

        public string GetModelStateError(ModelStateDictionary modelState)
        {
            string Msg = "";
            foreach (var state in modelState.Values)
            {
                foreach (var modelerror in state.Errors)
                {
                    Msg += modelerror.ErrorMessage + Environment.NewLine;
                }
            }
            return Msg;
        }

        public static List<CategoryViewModel> GetCategoryList()
        {
            List<CategoryViewModel> CList = new List<CategoryViewModel>();
            CategoryDAL.GetCategoriesList().ForEach(c => CList.Add(new CategoryViewModel(c)));
            return CList;
        }
        public static IEnumerable GetCategoryComboList(string CatType)
        {
            return CategoryDAL.GetCategoriesComboList(CatType);
        }
        #endregion
    }
}