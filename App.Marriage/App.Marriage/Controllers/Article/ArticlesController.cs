﻿using App.Marriage.DAL;
using App.Marriage.Models.ArticleMV;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Controllers.Article
{
    public class ArticlesController : Controller
    {

        private string ArticleView = "~/Views/Articles/_ArticalGVP.cshtml";
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HtmlEditorPartial(string Id)
        {
            int Article_Id = Int32.Parse(Id);
            ArticleViewModel article = new ArticleViewModel();
            if (Article_Id > 0)
            {
                ArticleDAL articleDal = new ArticleDAL(Article_Id);
                article = new ArticleViewModel(articleDal);
            }

            return PartialView("_HtmlEditor", article);
        }

        [ValidateInput(false)]
        public ActionResult ArticalGVP()
        {
            var model = ArticleViewModel.GetArticalList();
            return PartialView(ArticleView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ArticalGVPAddNew([ModelBinder(typeof(DevExpressEditorsBinder))]  ArticleViewModel Article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new Article in your model
                    Article.Create();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = Article.GetModelStateError(ModelState);

            ViewData["ContentsValue"] = Article.Contents;
            var model = ArticleViewModel.GetArticalList();
            return PartialView(ArticleView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ArticalGVPUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]  ArticleViewModel Article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the Article in your model
                    Article.Update();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = Article.GetModelStateError(ModelState);

            ViewData["ContentsValue"] = Article.Contents;
            var model = ArticleViewModel.GetArticalList();
            return PartialView(ArticleView, model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ArticalGVPDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the Article from your model
                    var Article = ArticleViewModel.Find(Id);
                    Article.Delete();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = ArticleViewModel.GetArticalList();
            return PartialView(ArticleView, model);
        }
    }
}