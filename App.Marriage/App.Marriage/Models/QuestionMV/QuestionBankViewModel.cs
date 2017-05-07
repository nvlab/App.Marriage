using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.DAL;
using System.Collections;

namespace App.Marriage.Models.QuestionMV
{
    public class QuestionBankViewModel
    {
        #region Properties
        int _id;
        string _Question;
        int? _CatID;
        int? _EntityOrder;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Question
        {
            get { return _Question; }
            set { _Question = value; }
        }

        public int? CatID
        {
            get { return _CatID; }
            set { _CatID = value; }
        }
        public int? EntityOrder
        {
            get { return _EntityOrder; }
            set { _EntityOrder = value; }
        }

        #endregion

        #region Constractors
        public QuestionBankViewModel(QuestionBankDAL Q)
        {
            _id = Q.QuestionBanks.Id;
            _Question = Q.QuestionBanks.Question;
            _EntityOrder = Q.QuestionBanks.Entity_Order;
            _CatID = Q.QuestionBanks.Category_Id;
        }
        public QuestionBankViewModel(int Id,string Question, int EntityOrder, int CatID)
        {
            _id = Id;
            _Question = Question;
            _EntityOrder = EntityOrder;
            _CatID = CatID;
        }
        public QuestionBankViewModel(int Id)
        {
            _id = Id;
        }
        #endregion

        #region operations
        public void Create()
        {
            QuestionBankDAL Q = new QuestionBankDAL();
            Q.QuestionBanks.Id = _id;
            Q.QuestionBanks.Question = _Question;
            Q.QuestionBanks.Category_Id = _CatID;
            Q.QuestionBanks.Entity_Order = _EntityOrder;

            Q.Create();

            _id = Q.QuestionBanks.Id;
        }

        public void Update()
        {
            QuestionBankDAL Q = new QuestionBankDAL(_id);

            if (!string.IsNullOrEmpty(_Question))
                Q.QuestionBanks.Question = _Question;

            if (_EntityOrder!=null)
                Q.QuestionBanks.Entity_Order = _EntityOrder;

            if (_CatID != null)
                Q.QuestionBanks.Category_Id = _CatID;

            Q.Update();
        }

        public void Delete()
        {
            QuestionBankDAL Q = new QuestionBankDAL(_id);
            Q.Delete();
        }
        #endregion

        #region Buseness Func

        public static List<QuestionBankViewModel> GetQuestionList()
        {
            List<QuestionBankViewModel> QList = new List<QuestionBankViewModel>();
            QuestionBankDAL.GetQuestionsList().ForEach(q => QList.Add(new QuestionBankViewModel(q)));
            return QList;
        }

        public static IEnumerable GetQuestionComboList()
        {
            return QuestionBankDAL.GetQuestionsComboList();
        }
        #endregion


    }
}