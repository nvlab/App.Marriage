using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Marriage.Entities;
using System.Collections;

namespace App.Marriage.DAL
{
    public class UserDAL
    {
        #region Properties
        private SOKNAEntities db;
        private Users _users;
        public Users Users
        {
            get { return _users; }
            set { _users = value; }
        }
        #endregion

        #region Constractors
        public UserDAL()
        {
            _users = new Users();

        }

        public UserDAL(int Id)
        {
            db = new SOKNAEntities();
            _users = db.Users.Single(u => u.Id == Id);
        }
        public UserDAL(Users Ua)
        {
            _users = Ua;
        }

        #endregion

        #region Operation Main Functions
        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.Users.Add(this._users);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            db.SaveChanges();
        }
        public void Delete()
        {
            db.Users.Remove(this._users);
            db.SaveChanges();
        }

        #endregion

        #region Business Function
        public static List<UserDAL> GetUsersList()
        {
            List<UserDAL> List = new List<UserDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.Users.ToList();
                Res.ForEach(r => List.Add(new UserDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetUsersComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Users.Select(r => new { Name = r.UserName, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion



    }
}