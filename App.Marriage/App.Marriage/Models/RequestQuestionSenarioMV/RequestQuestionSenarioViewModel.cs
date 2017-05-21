using App.Marriage.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Models.RequestQuestionSenarioMV
{
    public class RequestQuestionSenarioViewModel
    {
        #region properties
        private int _Id;
        private int? _Question_id;
        private int? _RegisterRequests_Id;
        private string _Answers;
        private int? _Entity_Order;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int? Question_id
        {
            get { return _Question_id; }
            set { _Question_id = value; }
        }
        public int? RegisterRequests_Id
        {
            get { return _RegisterRequests_Id; }
            set { _RegisterRequests_Id = value; }
        }

        public string Answers
        {
            get { return _Answers; }
            set { _Answers = value; }
        }

        public int? Entity_Order
        {
            get { return _Entity_Order; }
            set { _Entity_Order = value; }
        }
        #endregion

        #region Constractors
        public RequestQuestionSenarioViewModel()
        {

        }
        public RequestQuestionSenarioViewModel(RequestQuestionSenarioDAL R)
        {
            _Id = R.RequestQuestionSenario.Id;
            _Question_id = R.RequestQuestionSenario.Question_id.GetValueOrDefault();
            _RegisterRequests_Id = R.RequestQuestionSenario.RegisterRequests_Id.GetValueOrDefault();
            _Answers = R.RequestQuestionSenario.Answers;
            _Entity_Order = R.RequestQuestionSenario.Entity_Order.GetValueOrDefault();
        }

        public RequestQuestionSenarioViewModel(int Id, int? Question_id, int? RegisterRequests_Id, string Answers,int? Entity_Order)
        {
            _Id = Id;
            _Question_id = Question_id;
            _RegisterRequests_Id = RegisterRequests_Id;
            _Answers = Answers;
            _Entity_Order = Entity_Order;
        }

        public RequestQuestionSenarioViewModel(int Id)
        {
            _Id = Id;
        }
        #endregion

        #region Operations
        public void Create()
        {
            RequestQuestionSenarioDAL R = new RequestQuestionSenarioDAL();
            //R.RequestQuestionSenario.Id = _Id;
            R.RequestQuestionSenario.Question_id = _Question_id;
            R.RequestQuestionSenario.RegisterRequests_Id = _RegisterRequests_Id;
            R.RequestQuestionSenario.Answers = _Answers;
            R.RequestQuestionSenario.Entity_Order = _Entity_Order;

            R.Create();

            _Id = R.RequestQuestionSenario.Id;

        }

        public void Update()
        {
            RequestQuestionSenarioDAL R = new RequestQuestionSenarioDAL();

            if (_Question_id != null && _Question_id != 0)
                R.RequestQuestionSenario.Question_id = _Question_id;

            if (_RegisterRequests_Id != null && _RegisterRequests_Id != 0)
                R.RequestQuestionSenario.RegisterRequests_Id = _RegisterRequests_Id;

            if (_Answers != null)
                R.RequestQuestionSenario.Answers = _Answers;

            if (_Entity_Order != null)
                R.RequestQuestionSenario.Entity_Order = _Entity_Order;

            R.Update();
        }

        public void Delete()
        {
            RequestQuestionSenarioDAL R = new RequestQuestionSenarioDAL(_Id);
            R.Delete();
        }
        #endregion

        #region Nuseiess Functions
        public static List<RequestQuestionSenarioViewModel> GetRequestQuestionSenarioList()
        {
            List<RequestQuestionSenarioViewModel> RList = new List<RequestQuestionSenarioViewModel>();
            RequestQuestionSenarioDAL.GetRequestQuestionSenarioList().ForEach(r => RList.Add(new RequestQuestionSenarioViewModel(r)));
            return RList;
        }
        public static List<RequestQuestionSenarioViewModel> GetRequestQuestionSenarioListByRegisterRequests_Id(int RegisterRequests_Id)
        {
            List<RequestQuestionSenarioViewModel> RList = new List<RequestQuestionSenarioViewModel>();
            RequestQuestionSenarioDAL.GetRequestQuestionSenarioListByRegisterRequests_Id(RegisterRequests_Id).ForEach(r => RList.Add(new RequestQuestionSenarioViewModel(r)));
            return RList;
        }
        public IEnumerable GetRequestQuestionSenarioComboList()
        {
            return RequestQuestionSenarioDAL.GetRequestQuestionSenarioComboList();

        }
        #endregion
    }
}