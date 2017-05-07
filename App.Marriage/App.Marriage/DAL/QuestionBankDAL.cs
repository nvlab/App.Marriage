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
        SOKNAEntities  Db;
        private QuestionBank _QuestionBanks;
        public QuestionBank QuestionBanks
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
            Db = new SOKNAEntities();
            _QuestionBanks = Db.QuestionBank.Single(r => r.Id == Id);
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
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.QuestionBank.Remove(_QuestionBanks);
            Db.SaveChanges();
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