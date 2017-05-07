using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class CategoryDAL
    {
        #region Properties

        SOKNAEntities Db = new SOKNAEntities();
        private Category _Categories;
        public Category Categories
        {
            get { return _Categories; }
            set { _Categories = value; }

        }

        #endregion

        #region Construction Functions

        public CategoryDAL()
        {
            _Categories = new Category();
        }

        public CategoryDAL(int Id)
        {
            Db = new SOKNAEntities();
            _Categories = Db.Category.Single(r => r.Id == Id);
        }

        public CategoryDAL(Category Ca)
        {
            _Categories = Ca;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Category.Add(_Categories);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.Category.Remove(_Categories);
            Db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<CategoryDAL> GetCategoriesList()
        {
            List<CategoryDAL> List = new List<CategoryDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Category.ToList();
                Res.ForEach(r => List.Add(new CategoryDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetCategoriesComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Category.Select(r => new { Name = r.CategoryName, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion
    }
}