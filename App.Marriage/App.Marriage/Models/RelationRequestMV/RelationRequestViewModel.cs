using App.Marriage.DAL;
using App.Marriage.Models.PersonMV;
using App.Marriage.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Marriage.Models.RelationRequestMV
{
    public class RelationRequestViewModel : IValidatableObject
    {
        #region Properties
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int? _RequestUser_Id;

        public int? RequestUser_Id
        {
            get { return _RequestUser_Id; }
            set { _RequestUser_Id = value; }
        }

        private int? _RegisterRequests_Id;

        public int? RegisterRequests_Id
        {
            get { return _RegisterRequests_Id; }
            set { _RegisterRequests_Id = value; }
        }

        private int? _TargetUser_Id;

        public int? TargetUser_Id
        {
            get { return _TargetUser_Id; }
            set { _TargetUser_Id = value; }
        }


        private DateTime? _RequestDate;

        public DateTime? RequestDate
        {
            get { return _RequestDate; }
            set { _RequestDate = value; }
        }

        private string _RequestMessage;

        public string RequestMessage
        {
            get { return _RequestMessage; }
            set { _RequestMessage = value; }
        }

        private string _ResponseMessage;

        public string ResponseMessage
        {
            get { return _ResponseMessage; }
            set { _ResponseMessage = value; }
        }
        private string _RequestStatus;

        public string RequestStatus
        {
            get { return _RequestStatus; }
            set { _RequestStatus = value; }
        }

        private bool? _AllowChatRoom;

        public bool? AllowChatRoom
        {
            get { return _AllowChatRoom; }
            set { _AllowChatRoom = value; }
        }

        private int? _ResponsibleManager_Id;

        public int? ResponsibleManager_Id
        {
            get { return _ResponsibleManager_Id; }
            set { _ResponsibleManager_Id = value; }
        }

        #endregion
        #region Constractors
        public RelationRequestViewModel(RelationRequestDAL U)
        {
            _Id = U.RelationRequest.Id;
            _RequestUser_Id = U.RelationRequest.RequestUser_Id;
            _RegisterRequests_Id = U.RelationRequest.RegisterRequests_Id;
            _TargetUser_Id = U.RelationRequest.TargetUser_Id;
            _RequestDate = U.RelationRequest.RequestDate;
            _RequestMessage = U.RelationRequest.RequestMessage;
            _ResponseMessage = U.RelationRequest.ResponseMessage;
            _RequestStatus = U.RelationRequest.RequestStatus;
            _AllowChatRoom = U.RelationRequest.AllowChatRoom;
            _ResponsibleManager_Id = U.RelationRequest.ResponsibleManager_Id;
        }

        public RelationRequestViewModel(int Id, int RequestUser_Id, int RegisterRequests_Id, int TargetUser_Id, DateTime RequestDate, string RequestMessage, string ResponseMessage, string RequestStatus, bool AllowChatRoom, int ResponsibleManager_Id)
        {
            _Id = Id;
            _RequestUser_Id = RequestUser_Id;
            _RegisterRequests_Id = RegisterRequests_Id;
            _TargetUser_Id = TargetUser_Id;
            _RequestDate = RequestDate;
            _RequestMessage = RequestMessage;
            _ResponseMessage = ResponseMessage;
            _RequestStatus = RequestStatus;
            _AllowChatRoom = AllowChatRoom;
            _ResponsibleManager_Id = ResponsibleManager_Id;

        }

        public RelationRequestViewModel(int Id)
        {
            _Id = Id;
        }
        public RelationRequestViewModel()
        {

        }
        #endregion

        #region Operations
        public void Create()
        {
            RelationRequestDAL U = new RelationRequestDAL();
            U.RelationRequest.Id = _Id;
            U.RelationRequest.RequestUser_Id = _RequestUser_Id;
            U.RelationRequest.RegisterRequests_Id = _RegisterRequests_Id;
            U.RelationRequest.TargetUser_Id = _TargetUser_Id;
            U.RelationRequest.RequestDate = _RequestDate;
            U.RelationRequest.RequestMessage = _RequestMessage;
            U.RelationRequest.ResponseMessage = _ResponseMessage;
            U.RelationRequest.RequestStatus = _RequestStatus;
           // U.RelationRequest.AllowChatRoom = _AllowChatRoom;
           // U.RelationRequest.ResponsibleManager_Id = _ResponsibleManager_Id;
            

            U.Create();

            _Id = U.RelationRequest.Id;
        }

        public void Update()
        {
            RelationRequestDAL U = new RelationRequestDAL(_Id);


            if (_RequestUser_Id != 0 && _RequestUser_Id != null)
                U.RelationRequest.RequestUser_Id = _RequestUser_Id;
            if (_RegisterRequests_Id != 0 && _RegisterRequests_Id != null)
                U.RelationRequest.RegisterRequests_Id = _RegisterRequests_Id;
            if (_TargetUser_Id != 0 && _TargetUser_Id != null)
                U.RelationRequest.TargetUser_Id = _TargetUser_Id;
            if (_RequestDate != new DateTime() && _RequestDate != null)
                U.RelationRequest.RequestDate = _RequestDate;
            if (_RequestMessage != null)
                U.RelationRequest.RequestMessage = _RequestMessage;
            if (_ResponseMessage != null)
                U.RelationRequest.ResponseMessage = _ResponseMessage;
            if (_RequestStatus != null)
                U.RelationRequest.RequestStatus = _RequestStatus;
            if (_AllowChatRoom != null)
                U.RelationRequest.AllowChatRoom = _AllowChatRoom;
            if (_ResponsibleManager_Id != 0 && _ResponsibleManager_Id != null)
                U.RelationRequest.ResponsibleManager_Id = _ResponsibleManager_Id;

            U.Update();

        }

        public void Delete()
        {
            ChatRoomMessageDAL U = new ChatRoomMessageDAL(_Id);
            U.Delete();
        }

        public static RelationRequestViewModel Find(int Id)
        {
            return new RelationRequestViewModel(new RelationRequestDAL(Id));
        }

        #endregion

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (_NationalNumber.ToString().Length<=NationalLength.IntValue)
            //{
            //yield return new ValidationResult(GlobalLocalized.FieldLength + " " +NationalLength.IntValue, new[] { "NationalNumber" });
            //}

            if (_Id == null)
            {
                yield return new ValidationResult(Globalization.FieldIsRequired, new[] { "Id" });
            }
            // return null;
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

        #region Busniss Func
        public static List<RelationRequestViewModel> GetRelationRequestList()
        {
            List<RelationRequestViewModel> UList = new List<RelationRequestViewModel>();
            RelationRequestDAL.GetRelationRequestList().ForEach(r => UList.Add(new RelationRequestViewModel(r)));
            return UList;
        }
        public static IEnumerable GetRelationRequestComboList()
        {
            return RelationRequestDAL.GetRelationRequestComboList();
        }


        public static PersonViewModel GetSourcePerson(int Id)
        {
            RelationRequestDAL Rel = new DAL.RelationRequestDAL(Id);
            var SourceUsers_Id = Rel.RelationRequest.SourceUsers.Id;
            var GetPersonId = RelationRequestDAL.GetPersonId(SourceUsers_Id);
            return PersonViewModel.Find(GetPersonId);
        }

        public static PersonViewModel GetTargetPerson(int Id)
        {
            RelationRequestDAL Rel = new DAL.RelationRequestDAL(Id);
            return PersonViewModel.Find(RelationRequestDAL.GetPersonId(Rel.RelationRequest.TargetUsers.Id));
        }

        #endregion
    }
}