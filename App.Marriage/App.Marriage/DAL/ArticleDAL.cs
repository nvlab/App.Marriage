using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class ArticleDAL

    {
        #region Properties

        SOKNAEntities Db = new SOKNAEntities();
        private Articles _Articles;
        public Articles Articles
        {
            get { return _Articles; }
            set { _Articles = value; }

        }

        #endregion

        #region Construction Functions

        public ArticleDAL()
        {
            _Articles = new Articles();
        }

        public ArticleDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Articles = Db.Articles.Single(r => r.Id == Id);
        }

        public ArticleDAL(Articles Aa)
        {
            _Articles = Aa;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Articles.Add(_Articles);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Articles.Remove(_Articles);
            Db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<ArticleDAL> GetArticlesList()
        {
            List<ArticleDAL> List = new List<ArticleDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Articles.ToList();
                Res.ForEach(r => List.Add(new ArticleDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetArticlesComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Articles.Select(r => new { Name = r.Titles, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion
    }
}