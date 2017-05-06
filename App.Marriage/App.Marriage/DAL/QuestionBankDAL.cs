using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class QuestionBankDAL
    {
        #region Properties
        SOKNAEntities db;
        QuestionBank _QuestionBanks;
        QuestionBank QuestionBanks
        {
            get { return _QuestionBanks; }
            set { _QuestionBanks = value; }

        }
        #endregion

        #region Construction Functions

        public QuestionBankDAL()
        {
            _QuestionBanks= new QuestionBank();
        }

        public QuestionBankDAL(int Id)
        {
            db = new SOKNAEntities();
            _QuestionBanks = db.QuestionBank.Single(r => r.Id == Id);
        }

        public QuestionBankDAL(QuestionBank Qa)
        {
            _QuestionBanks = Qa;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.QuestionBank.Add(_QuestionBanks);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            db.SaveChanges();
        }

        public void Delete()
        {
            db.QuestionBank.Remove(_QuestionBanks);
            db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<QuestionBankDAL> GetQuestionsList()
        {
            List<QuestionBankDAL> List = new List<QuestionBankDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.QuestionBank.ToList();
                Res.ForEach(r => List.Add(new QuestionBankDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetQuestionsComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.QuestionBank.Select(r => new { Name = r.Question, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion
    }
}