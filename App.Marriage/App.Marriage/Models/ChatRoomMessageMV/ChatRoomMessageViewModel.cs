using App.Marriage.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Models.ChatRoomMessageMV
{
    public class ChatRoomMessageViewModel
    {
        #region Properties
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private int? _RelationRequest_Id;

        public int? RelationRequest_Id
        {
            get { return _RelationRequest_Id; }
            set { _RelationRequest_Id = value; }
        }

        private int ?_SenderUser_Id;

        public int? SenderUser_Id
        {
            get { return _SenderUser_Id; }
            set { _SenderUser_Id = value; }
        }

        private DateTime? _MsgDate;

        public DateTime? MsgDate
        {
            get { return _MsgDate; }
            set { _MsgDate = value; }
        }

        private int? _Entity_Order;

        public int? Entity_Order
        {
            get { return _Entity_Order; }
            set { _Entity_Order = value; }
        }

      



        #endregion

        #region Constractors
        public ChatRoomMessageViewModel(ChatRoomMessageDAL U)
        {
            _Id = U.ChatRoomMessages.Id;
            _Message = U.ChatRoomMessages.Message;
            _MsgDate = U.ChatRoomMessages.MsgDate;
            _SenderUser_Id = U.ChatRoomMessages.SenderUser_Id;
            _RelationRequest_Id = U.ChatRoomMessages.RelationRequest_Id;
            _Entity_Order = U.ChatRoomMessages.Entity_Order;
            _IMG = PersonDAL.GetPersonPhotoByUserId(U.ChatRoomMessages.SenderUser_Id).Persons.Photo1;
            _SenderFullName = PersonDAL.GetPersonPhotoByUserId(U.ChatRoomMessages.SenderUser_Id).Persons.FullName;
        }

        public ChatRoomMessageViewModel(int Id, string Message, DateTime MsgDate, int SenderUser_Id, int RelationRequest_Id, int Entity_Order)
        {
            _Id = Id;
            _Message = Message;
            _MsgDate = MsgDate;
            _SenderUser_Id = SenderUser_Id;
            _RelationRequest_Id = RelationRequest_Id;
            _Entity_Order = Entity_Order;
        }

    

        public ChatRoomMessageViewModel(int Id)
        {
            _Id = Id;
        }
        public ChatRoomMessageViewModel()
        {

        }
        #endregion

        #region Operations
        public void Create()
        {
            ChatRoomMessageDAL U = new ChatRoomMessageDAL();
            U.ChatRoomMessages.Id = _Id;
            U.ChatRoomMessages.Message = _Message;
            U.ChatRoomMessages.MsgDate = _MsgDate;
            U.ChatRoomMessages.RelationRequest_Id = _RelationRequest_Id;
            U.ChatRoomMessages.SenderUser_Id = _SenderUser_Id;
            U.ChatRoomMessages.Entity_Order = _Entity_Order;

            U.Create();

            _Id = U.ChatRoomMessages.Id;
        }

        public void Update()
        {
            ChatRoomMessageDAL U = new ChatRoomMessageDAL(_Id);
            if (!string.IsNullOrEmpty(_Message))
                U.ChatRoomMessages.Message = _Message;

            if(_MsgDate !=new DateTime() && _MsgDate!=null)
                U.ChatRoomMessages.MsgDate = _MsgDate;
            if(_Entity_Order!=null)
                U.ChatRoomMessages.Entity_Order = _Entity_Order;

            if (_RelationRequest_Id != 0 && _RelationRequest_Id != null)
                U.ChatRoomMessages.RelationRequest_Id = _RelationRequest_Id;
            if (_SenderUser_Id != 0 && _SenderUser_Id != null)
                U.ChatRoomMessages.SenderUser_Id = _SenderUser_Id;

            U.Update();

        }

        public void Delete()
        {
            ChatRoomMessageDAL U = new ChatRoomMessageDAL(_Id);
            U.Delete();
        }

        public static ChatRoomMessageViewModel Find(int Id)
        {
            return new ChatRoomMessageViewModel(new ChatRoomMessageDAL(Id));
        }

        #endregion

        #region Busniss Func
        public static List<ChatRoomMessageViewModel> GetChatRoomMessagesList()
        {
            List<ChatRoomMessageViewModel> UList = new List<ChatRoomMessageViewModel>();
            ChatRoomMessageDAL.GetChatRoomMessagesList().ForEach(u => UList.Add(new ChatRoomMessageViewModel(u)));
            return UList;
        }

        public static List<ChatRoomMessageViewModel> GetChatRoomMessagesByRelationRequest_IdList(int relationRequest_Id,int User_Id)
        {
            List<ChatRoomMessageViewModel> UList = new List<ChatRoomMessageViewModel>();
            ChatRoomMessageDAL.GetChatRoomMessagesByRelationRequest_IdList(relationRequest_Id).ForEach(u => UList.Add(new ChatRoomMessageViewModel(u)));
            foreach (var item in UList)
            {
                if (item.SenderUser_Id==User_Id)
                {
                    item.IsUserMsgSender = true;
                }
            }
            return UList;
        }

        public static List<ChatRoomMessageViewModel> LoadChatRoomNewMessages(int relationRequest_Id, int lastMessage, int User_Id)
        {
            List<ChatRoomMessageViewModel> UList = new List<ChatRoomMessageViewModel>();
            ChatRoomMessageDAL.LoadChatRoomNewMessages(relationRequest_Id, lastMessage).ForEach(u => UList.Add(new ChatRoomMessageViewModel(u)));
            foreach (var item in UList)
            {
                if (item.SenderUser_Id == User_Id)
                {
                    item.IsUserMsgSender = true;
                }
            }
            return UList;
        }
        public static IEnumerable GetUserComboList()
        {
            return ChatRoomMessageDAL.GetChatRoomMessagesComboList();
        }
        #endregion

        #region Parameter buissness
        private bool _IsUserMsgSender;

        public bool IsUserMsgSender
        {
            get { return _IsUserMsgSender; }
            set { _IsUserMsgSender = value; }
        }
        private string _IMG;

        public string IMG
        {
            get { return _IMG; }
            set { _IMG = value; }
        }
        private string _SenderFullName;

        public string SenderFullName
        {
            get { return _SenderFullName; }
            set { _SenderFullName = value; }
        }


        #endregion
    }
}