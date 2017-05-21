using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.DAL;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using App.Marriage.Utils;
using System.Web.Mvc;

namespace App.Marriage.Models.ArticleMV
{
    public class ArticleViewModel : IValidatableObject
    {
        #region Properties
        private int _Id;
        private string _Titles;
        private string _Description;
        private string _Contents;
        private string _Status;
        private int? _Category_Id;
        private int? _Entity_Order;
        private bool? _IsPublish;
        private DateTime? _ArticalDate;
        private string _Artical_Image;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Titles
        {
            get { return _Titles; }
            set { _Titles = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string Contents
        {
            get { return _Contents; }
            set { _Contents = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int? Category_Id
        {
            get { return _Category_Id; }
            set { _Category_Id = value; }
        }
        public int? Entity_Order
        {
            get { return _Entity_Order; }
            set { _Entity_Order = value; }
        }

        public bool? IsPublish
        {
            get { return _IsPublish; }
            set { _IsPublish = value; }
        }

        public DateTime? ArticalDate
        {
            get { return _ArticalDate; }
            set { _ArticalDate = value; }
        }

        public string Artical_Image
        {
            get { return _Artical_Image; }
            set { _Artical_Image = value; }
        }
        #endregion

        #region Constructors
        public ArticleViewModel(ArticleDAL A)
        {
            _Id = A.Articles.Id;
            _Titles = A.Articles.Titles;
            _Description = A.Articles.Description;
            _Contents = A.Articles.Contents;
            _Status = A.Articles.Status;
            _Category_Id = A.Articles.Category_Id;
            _Entity_Order = A.Articles.Entity_Order;
            _IsPublish = A.Articles.IsPublish;
            _ArticalDate = A.Articles.ArticalDate;
            _Artical_Image = A.Articles.Artical_Image;

        }

        public ArticleViewModel(int Id, string Title, string Description, string Content, string Status, int CatId, int EntityOrder, bool IsPublish, DateTime ArticleDate, string ArticleImage)
        {
            _Id = Id;
            _Titles = Title;
            _Description = Description;
            _Contents = Content;
            _Status = Status;
            _Category_Id = CatId;
            _Entity_Order = EntityOrder;
            _IsPublish = IsPublish;
            _ArticalDate = ArticleDate;
            _Artical_Image = ArticleImage;

        }
        public ArticleViewModel(int Id)
        {
            _Id = Id;
        }


        public ArticleViewModel()
        {

        }
        #endregion

        #region Operations
        public void Create()
        {
            ArticleDAL Ar = new ArticleDAL();

            Ar.Articles.Id = _Id;
            Ar.Articles.Titles = _Titles;
            Ar.Articles.Description = _Description;
            Ar.Articles.Contents = _Contents;
            Ar.Articles.Status = _Status;
            Ar.Articles.Category_Id = _Category_Id;
            Ar.Articles.Entity_Order = _Entity_Order;
            Ar.Articles.IsPublish = _IsPublish;
            Ar.Articles.ArticalDate = _ArticalDate;
            Ar.Articles.Artical_Image = _Artical_Image;

            Ar.Create();

            _Id = Ar.Articles.Id;
        }

        public void Update()
        {
            ArticleDAL Ar = new ArticleDAL(_Id);

            if (!string.IsNullOrEmpty(_Titles))
                Ar.Articles.Titles = _Titles;

            if (!string.IsNullOrEmpty(_Description))
                Ar.Articles.Description = _Description;

            if (!string.IsNullOrEmpty(_Contents))
                Ar.Articles.Contents = _Contents;

            if (!string.IsNullOrEmpty(_Status))
                Ar.Articles.Status = _Status;

            if (_Category_Id!=null)
                Ar.Articles.Category_Id = _Category_Id;

            if (_Entity_Order != null)
                Ar.Articles.Entity_Order = _Entity_Order;

            if (_IsPublish!=null)
                Ar.Articles.IsPublish = _IsPublish;

            if (_ArticalDate!=null)
                Ar.Articles.ArticalDate = _ArticalDate;

            if (!string.IsNullOrEmpty(_Artical_Image))
                Ar.Articles.Artical_Image = _Artical_Image;

            Ar.Update();
        }
        public void Delete()
        {
            ArticleDAL Ar = new ArticleDAL(_Id);
            Ar.Delete();
        }
        public static ArticleViewModel Find(int Id)
        {
            return new ArticleViewModel(new ArticleDAL(Id));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (_NationalNumber.ToString().Length<=NationalLength.IntValue)
            //{
            //yield return new ValidationResult(GlobalLocalized.FieldLength + " " +NationalLength.IntValue, new[] { "NationalNumber" });
            //}

            if (_Titles == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "_Title" });
            }

            if (_Category_Id == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "_Category_Id" });
            }

            if (_Description == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "_Description" });
            }

            if (_ArticalDate == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "_ArticleDate" });
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

        #endregion

        #region Busniss Func
        public static List<ArticleViewModel> GetArticalList()
        {
            List<ArticleViewModel> AList = new List<ArticleViewModel>();
            ArticleDAL.GetArticlesList().ForEach(a => AList.Add(new ArticleViewModel(a)));
            return AList;
        }
        public static IEnumerable GetArticalComboList()
        {
            return ArticleDAL.GetArticlesComboList();
        }
        #endregion

    }
}