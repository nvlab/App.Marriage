using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.DAL;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using App.Marriage.Utils;
using System.Web.Mvc;

namespace App.Marriage.Models.QuestionMV
{
    public class QuestionBankViewModel : IValidatableObject
    {
        #region Properties
        int _Id;
        string _Question;
        int? _Category_Id;
        int? _Entity_Order;


        private string _Image;

        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        public string Question
        {
            get { return _Question; }
            set { _Question = value; }
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

        #endregion

        #region Constractors
        public QuestionBankViewModel(QuestionBankDAL Q)
        {
            _Id = Q.QuestionBanks.Id;
            _Question = Q.QuestionBanks.Question;
            _Entity_Order = Q.QuestionBanks.Entity_Order;
            _Category_Id = Q.QuestionBanks.Category_Id;
        }
        public QuestionBankViewModel(int Id,string Question, int EntityOrder, int CatID)
        {
            _Id = Id;
            _Question = Question;
            _Entity_Order = EntityOrder;
            _Category_Id = CatID;
        }
        public QuestionBankViewModel(int Id)
        {
            _Id = Id;
        }

        public QuestionBankViewModel() { }
        #endregion

        #region operations
        public void Create()
        {
            QuestionBankDAL Q = new QuestionBankDAL();
            Q.QuestionBanks.Id = _Id;
            Q.QuestionBanks.Question = _Question;
            Q.QuestionBanks.Category_Id = _Category_Id;
            Q.QuestionBanks.Entity_Order = _Entity_Order;

            Q.Create();

            _Id = Q.QuestionBanks.Id;
        }

        public void Update()
        {
            QuestionBankDAL Q = new QuestionBankDAL(_Id);

            if (!string.IsNullOrEmpty(_Question))
                Q.QuestionBanks.Question = _Question;

            if (_Entity_Order!=null)
                Q.QuestionBanks.Entity_Order = _Entity_Order;

            if (_Category_Id != null)
                Q.QuestionBanks.Category_Id = _Category_Id;

            Q.Update();
        }

        public void Delete()
        {
            QuestionBankDAL Q = new QuestionBankDAL(_Id);
            Q.Delete();
        }

        public static QuestionBankViewModel Find(int Id)
        {
            return new QuestionBankViewModel(new QuestionBankDAL(Id));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           

            if (_Category_Id == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "_Title" });
            }

            if (_Question == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "_Category_Id" });
            }

          
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

        #region Buseness Func

        public static List<QuestionBankViewModel> GetQuestionBankList()
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