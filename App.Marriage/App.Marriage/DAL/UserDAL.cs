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
        private SOKNAEntities Db;
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
            Db = new SOKNAEntities();
            _users = Db.Users.Single(u => u.Id == Id);
        }
        /// <summary>
        /// Get User By Email
        /// </summary>
        /// <param name="Email"></param>
        public UserDAL(string Email)
        {
            Db = new SOKNAEntities();
            _users = Db.Users.Single(u => u.Email == Email);
        }
        public UserDAL(string UserName,string Password)
        {
            Db = new SOKNAEntities();
            var Res = Db.Users.Where(u => u.UserName == UserName && u.UserPassword == Password);
            if (Res.Count() > 0)
            {
                _users = Res.First();
            }
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
            Db.SaveChanges();
        }
        public void Delete()
        {
            Db.Users.Remove(this._users);
            Db.SaveChanges();
        }

        public static UserDAL Find(int Id)
        {
            return new UserDAL(Id);
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

        public static IEnumerable GetUsersNamesComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.Users.Select(r => new { Name = r.Person.FirstOrDefault().FullName, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion



    }
}