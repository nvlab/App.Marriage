using App.Marriage.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.DAL
{
    public class ChatRoomMessageDAL
    {
        #region Properties

        SOKNAEntities Db = new SOKNAEntities();
        private ChatRoomMessage _ChatRoomMessages;
        public ChatRoomMessage ChatRoomMessages
        {
            get { return _ChatRoomMessages; }
            set { _ChatRoomMessages = value; }

        }

        #endregion

        #region Construction Functions

        public ChatRoomMessageDAL()
        {
            _ChatRoomMessages = new ChatRoomMessage();
        }

        public ChatRoomMessageDAL(int Id)
        {
            Db = new SOKNAEntities();
            _ChatRoomMessages = Db.ChatRoomMessage.Single(r => r.Id == Id);
        }

        public ChatRoomMessageDAL(ChatRoomMessage Ca)
        {
            _ChatRoomMessages = Ca;
        }



        #endregion

        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                if (db.ChatRoomMessage.Where(r => r.RelationRequest_Id == _ChatRoomMessages.RelationRequest_Id).Count() > 0)

                    _ChatRoomMessages.Entity_Order = db.ChatRoomMessage.Where(r => r.RelationRequest_Id == _ChatRoomMessages.RelationRequest_Id).Max(r => r.Entity_Order) + 1;
                else
                    _ChatRoomMessages.Entity_Order = 1;
                db.ChatRoomMessage.Add(_ChatRoomMessages);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.ChatRoomMessage.Remove(_ChatRoomMessages);
            Db.SaveChanges();
        }
        #endregion

        #region Business Function
        public static List<ChatRoomMessageDAL> GetChatRoomMessagesList()
        {
            List<ChatRoomMessageDAL> List = new List<ChatRoomMessageDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.ChatRoomMessage.ToList();
                Res.ForEach(r => List.Add(new ChatRoomMessageDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetChatRoomMessagesComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.ChatRoomMessage.Select(r => new { Name = r.Message, Id = r.Id }).ToList();
                return Res;
            }

        }

        public static List<ChatRoomMessageDAL>  GetChatRoomMessagesByRelationRequest_IdList(int relationRequest_Id)
        {

            List<ChatRoomMessageDAL> List = new List<ChatRoomMessageDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.ChatRoomMessage.Where(r=>r.RelationRequest_Id== relationRequest_Id).ToList();
                Res.ForEach(r => List.Add(new ChatRoomMessageDAL(r)));

            }
            return List;
        }

        public static List<ChatRoomMessageDAL> LoadChatRoomNewMessages(int relationRequest_Id, int lastMessage)
        {
            List<ChatRoomMessageDAL> List = new List<ChatRoomMessageDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.ChatRoomMessage.Where(r => r.RelationRequest_Id == relationRequest_Id && r.Id > lastMessage).ToList();
                Res.ForEach(r => List.Add(new ChatRoomMessageDAL(r)));

            }
            return List;
        }
        #endregion
    }
}