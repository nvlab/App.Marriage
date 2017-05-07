using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.DAL;
using System.Collections;

namespace App.Marriage.Models.ArticleMV
{
    public class ArticleViewModel
    {
        #region Properties
        private int _Id;
        private string _Title;
        private string _Description;
        private string _Content;
        private string _Status;
        private int? _CatID;
        private int? _EntityOrder;
        private bool? _IsPublish;
        private DateTime? _ArticleDate;
        private string _ArticleImage;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int? CatID
        {
            get { return CatID; }
            set { _CatID = value; }
        }
        public int? EntityOrder
        {
            get { return _EntityOrder; }
            set { _EntityOrder = value; }
        }

        public bool? IsPublish
        {
            get { return _IsPublish; }
            set { _IsPublish = value; }
        }

        public DateTime? ArticleDate
        {
            get { return _ArticleDate; }
            set { _ArticleDate = value; }
        }

        public string ArticleImage
        {
            get { return _ArticleImage; }
            set { _ArticleImage = value; }
        }
        #endregion

        #region Constructors
        public ArticleViewModel(ArticleDAL A)
        {
            _Id = A.Articles.Id;
            _Title = A.Articles.Titles;
            _Description = A.Articles.Description;
            _Content = A.Articles.Contents;
            _Status = A.Articles.Status;
            _CatID = A.Articles.Category_Id;
            _EntityOrder = A.Articles.Entity_Order;
            _IsPublish = A.Articles.IsPublish;
            _ArticleDate = A.Articles.ArticalDate;
            _ArticleImage = A.Articles.Artical_Image;

        }

        public ArticleViewModel(int Id, string Title, string Description, string Content, string Status, int CatId, int EntityOrder, bool IsPublish, DateTime ArticleDate, string ArticleImage)
        {
            _Id = Id;
            _Title = Title;
            _Description = Description;
            _Content = Content;
            _Status = Status;
            _CatID = CatId;
            _EntityOrder = EntityOrder;
            _IsPublish = IsPublish;
            _ArticleDate = ArticleDate;
            _ArticleImage = ArticleImage;

        }
        public ArticleViewModel(int Id)
        {
            _Id = Id;
        }

        #endregion

        #region Operations
        public void Create()
        {
            ArticleDAL Ar = new ArticleDAL();

            Ar.Articles.Id = _Id;
            Ar.Articles.Titles = _Title;
            Ar.Articles.Description = _Description;
            Ar.Articles.Contents = _Content;
            Ar.Articles.Status = _Status;
            Ar.Articles.Category_Id = _CatID;
            Ar.Articles.Entity_Order = _EntityOrder;
            Ar.Articles.IsPublish = _IsPublish;
            Ar.Articles.ArticalDate = _ArticleDate;
            Ar.Articles.Artical_Image = _ArticleImage;

            Ar.Create();

            _Id = Ar.Articles.Id;
        }

        public void Update()
        {
            ArticleDAL Ar = new ArticleDAL(_Id);

            if (!string.IsNullOrEmpty(_Title))
                Ar.Articles.Titles = _Title;

            if (!string.IsNullOrEmpty(_Description))
                Ar.Articles.Description = _Description;

            if (!string.IsNullOrEmpty(_Content))
                Ar.Articles.Contents = _Content;

            if (!string.IsNullOrEmpty(_Status))
                Ar.Articles.Status = _Status;

            if (_CatID!=null)
                Ar.Articles.Category_Id = _CatID;

            if (_EntityOrder != null)
                Ar.Articles.Entity_Order = _EntityOrder;

            if (_IsPublish!=null)
                Ar.Articles.IsPublish = _IsPublish;

            if (_ArticleDate!=null)
                Ar.Articles.ArticalDate = _ArticleDate;

            if (!string.IsNullOrEmpty(_ArticleImage))
                Ar.Articles.Artical_Image = _ArticleImage;

            Ar.Update();
        }
        public void Delete()
        {
            ArticleDAL Ar = new ArticleDAL(_Id);
            Ar.Delete();
        }
        #endregion

        #region Busniss Func
        public static List<ArticleViewModel> GetUserList()
        {
            List<ArticleViewModel> AList = new List<ArticleViewModel>();
            ArticleDAL.GetArticlesList().ForEach(a => AList.Add(new ArticleViewModel(a)));
            return AList;
        }
        public static IEnumerable GetUserComboList()
        {
            return ArticleDAL.GetArticlesComboList();
        }
        #endregion

    }
}