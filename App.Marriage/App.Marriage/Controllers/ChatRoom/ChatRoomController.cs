using App.Marriage.DAL;
using App.Marriage.Models.ChatRoomMessageMV;
using App.Marriage.Models.PersonMV;
using App.Marriage.Models.RegisterRequesMV;
using App.Marriage.Models.RelationRequestMV;
using App.Marriage.Models.UserMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace App.Marriage.Controllers.ChatRoom
{
    public class ChatRoomController : Controller
    {
        // GET: ChatRoom
        public ActionResult Index(int RelationRequest_Id,int User_Id)
        {
            var Request = new RelationRequestDAL(RelationRequest_Id);
            if (Request.RelationRequest.AllowChatRoom.GetValueOrDefault())
            {
                return View(SetViewBag(Request, User_Id));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public object SetViewBag(RelationRequestDAL Request, int User_Id)
        {

            /// Extract Relation Request Info
          

            /// Extract Source Person And Target person
            if (Request.RelationRequest.TargetUser_Id==User_Id)
            {
                ViewBag.SPerson = Request.RelationRequest.TargetUsers.Person.First();
                ViewBag.TPerson = Request.RelationRequest.SourceUsers.Person.First();
            }
            else
            {
                ViewBag.TPerson = Request.RelationRequest.TargetUsers.Person.First();
                ViewBag.SPerson = Request.RelationRequest.SourceUsers.Person.First();
            }

            /// Passing Data into the page which needed to display information 
            ViewBag.RelationRequest_Id = Request.RelationRequest.Id;
            ViewBag.ResposibleName = Request.RelationRequest.ResponseUsers.Person.First().FullName;
            ViewBag.ResponsiblePhone = Request.RelationRequest.ResponseUsers.Person.First().Phone1;
            ViewBag.RelationRequest = new RelationRequestViewModel(Request);
            return  ChatRoomMessageViewModel.GetChatRoomMessagesByRelationRequest_IdList(Request.RelationRequest.Id, User_Id);
        }

      
        public void GetViewBag()
        {

        }

        public ActionResult SendMsgRequest(string Msg,int User_Id,int RelationRequest_Id) 
        {
            var CRMsg = new ChatRoomMessageViewModel(0, Msg, DateTime.Now, User_Id, RelationRequest_Id,0);
            CRMsg.Create();
            return Json("Okay");
        }

        public ActionResult LoadChatRoomMessages(int LastMessage,int RelationRequest_Id,int User_Id)
        {
            var Msgs = ChatRoomMessageViewModel.LoadChatRoomNewMessages(RelationRequest_Id, LastMessage,User_Id).Where(r=>r.IsUserMsgSender!=true);
            var JsonList = Msgs.Select(r => new
            {
                r.IsUserMsgSender,
                r.Message,
                r.IMG,
                r.SenderFullName,
                r.Id
                
            }  );

            return Json(JsonList);
        }

    }
}

