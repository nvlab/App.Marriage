using System;
using App.Marriage.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace App.Marriage.Models.RegisterRequesMV
{
    public class RegisterRequestViewModels
    {
        #region Properties
        private int _Id;
        private DateTime? _RequestDate;
        private int? _Person_Id;
        private int? _RequestStatus;
        private int? _ResponseMessage;
        private string _Links;
        private string _RequestMessage;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public DateTime? RequestDate
        {
            get { return _RequestDate; }
            set { _RequestDate = value; }
        }
        public int? Person_Id
        {
            get { return _Person_Id; }
            set { _Person_Id = value; }

        }
        public int? RequestStatus
        {
            get { return _RequestStatus; }
            set { _RequestStatus = value; }
        }
        public int? ResponseMessage
        {
            get { return _ResponseMessage; }
            set { _ResponseMessage = value; }
        }
        public string Links
        {
            get { return _Links; }
            set { _Links = value; }

        }
        public string RequestMessage
        {
            get { return _RequestMessage; }
            set { _RequestMessage = value; }

        }
        #endregion
        #region Construction Functions

        public RegisterRequestViewModels()
        {
        }

        public RegisterRequestViewModels(RegisterRequestsDAL Pa)
        {
            _Id = Pa.RegisterRequests.Id;
            _RequestDate = Pa.RegisterRequests.RequestDate;
            _Person_Id = Pa.RegisterRequests.Person_Id;
            _RequestStatus = Pa.RegisterRequests.RequestStatus;
            _ResponseMessage = Pa.RegisterRequests.ResponseMessage;
            _Links = Pa.RegisterRequests.Links;
            _RequestMessage = Pa.RegisterRequests.RequestMessage;

        }
        public RegisterRequestViewModels(int Id,
        DateTime? RequestDate,
        int? Person_Id,
        int? RequestStatus,
        int? ResponseMessage,
        string Links,
        string RequestMessage
        )
        {
            _Id = Id;
            _RequestDate = RequestDate;
            _Person_Id = Person_Id;
            _RequestStatus = RequestStatus;
            _ResponseMessage = ResponseMessage;
            _Links = Links;
            _RequestMessage = RequestMessage;

        }
        public RegisterRequestViewModels(int Id)
        {
            _Id = Id;
        }
        public RegisterRequestViewModels(object item)
        {
            Type type = item.GetType();
            _Id = (int)type.GetProperty("Id").GetValue(item, null);
            _RequestDate = (DateTime)type.GetProperty("RequestDate").GetValue(item, null);
            _Person_Id = (int)type.GetProperty("Person_Id").GetValue(item, null);
            _RequestStatus = (int?)type.GetProperty("RequestStatus").GetValue(item, null);
            _ResponseMessage = (int?)type.GetProperty("ResponseMessage").GetValue(item, null);
            _Links = (string)type.GetProperty("Links").GetValue(item, null);
            _RequestMessage = (string)type.GetProperty("RequestMessage").GetValue(item, null);

        }
        #endregion
        #region Operation Main Functions

        public void Create()
        {
            RegisterRequestsDAL Pa = new RegisterRequestsDAL();
            Pa.RegisterRequests.Person_Id = _Person_Id;
            Pa.RegisterRequests.RequestDate = _RequestDate;
            Pa.RegisterRequests.RequestStatus = _RequestStatus;
            Pa.RegisterRequests.ResponseMessage = _ResponseMessage;

            Pa.Create();

            _Id = Pa.RegisterRequests.Id;
        }

        public void Update()
        {
            RegisterRequestsDAL Pa = new RegisterRequestsDAL(_Id);
            DateTime Validate = new DateTime();
            if (Validate != RequestDate) { Pa.RegisterRequests.RequestDate = _RequestDate; }
            if (_Person_Id != 0 && _Person_Id != null) { Pa.RegisterRequests.Person_Id = _Person_Id; }
            if (_RequestStatus != 0 && _RequestStatus != null) { Pa.RegisterRequests.RequestStatus = _RequestStatus; }
            if (_ResponseMessage != 0 && _ResponseMessage != null) { Pa.RegisterRequests.ResponseMessage = _ResponseMessage; }

            if (!string.IsNullOrEmpty(_Links)) { Pa.RegisterRequests.Links = _Links; }
            if (!string.IsNullOrEmpty(_RequestMessage)) { Pa.RegisterRequests.RequestMessage = _RequestMessage; }

            Pa.Update();
        }

        public void Delete()
        {
            RegisterRequestsDAL Pa = new RegisterRequestsDAL(_Id);
            Pa.Delete();
        }

        #endregion
        #region Business Function
        public static List<RegisterRequestViewModels> Get_RegisterRequestsList()
        {
            List<RegisterRequestViewModels> List = new List<RegisterRequestViewModels>();
            RegisterRequestsDAL.Get_RegisterRequestsList().ForEach(r => List.Add(new RegisterRequestViewModels(r)));
            return List;
        }

        public static IEnumerable GetRegisterRequestsComboList()
        {
            return RegisterRequestsDAL.GetRegisterRequestsComboList();
        }

        #endregion
    }
}