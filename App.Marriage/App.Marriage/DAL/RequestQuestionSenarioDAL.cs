using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class RequestQuestionSenarioDAL
    {
        #region Properties
        SOKNAEntities Db;
        private RequestQuestionSenario _RequestQuestionSenario;
        public RequestQuestionSenario RequestQuestionSenario
        {
            get { return _RequestQuestionSenario; }
            set { _RequestQuestionSenario = value; }
        }
        #endregion

        #region Construction Functions

        public RequestQuestionSenarioDAL()
        {
            _RequestQuestionSenario = new RequestQuestionSenario();
        }

        public RequestQuestionSenarioDAL(int Id)
        {
            Db = new SOKNAEntities();
            _RequestQuestionSenario = Db.RequestQuestionSenario.Single(r => r.Id == Id);
        }
        public RequestQuestionSenarioDAL(RequestQuestionSenario Ra)
        {
            _RequestQuestionSenario = Ra;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.RequestQuestionSenario.Add(_RequestQuestionSenario);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.RequestQuestionSenario.Remove(_RequestQuestionSenario);
            Db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<RequestQuestionSenarioDAL> GetRequestQuestionSenarioList()
        {
            List<RequestQuestionSenarioDAL> List = new List<RequestQuestionSenarioDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.RequestQuestionSenario.ToList();
                Res.ForEach(r => List.Add(new RequestQuestionSenarioDAL(r)));

            }
            return List;
        }
        /// <summary>
        /// قائمو اسئلة الطلب
        /// </summary>
        /// <param name="RegisterRequests_Id"></param>
        /// <returns></returns>
        public static List<RequestQuestionSenarioDAL> GetRequestQuestionSenarioListByRegisterRequests_Id(int RegisterRequests_Id)
        {
            List<RequestQuestionSenarioDAL> List = new List<RequestQuestionSenarioDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.RequestQuestionSenario.Where(x => x.RegisterRequests_Id == RegisterRequests_Id).ToList();
                Res.ForEach(r => List.Add(new RequestQuestionSenarioDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetRequestQuestionSenarioComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.RequestQuestionSenario.Select(r => new { Name = r.QuestionBank.Question, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion

    }
}