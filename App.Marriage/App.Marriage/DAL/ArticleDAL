using App.Marriage.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.DAL
{
    public class RegisterRequestsDAL
    {

        #region Properties

        private SOKNAEntities Db;
        private RegisterRequests _RegisterRequests;
        public RegisterRequests RegisterRequests
        {
            get { return _RegisterRequests; }
            set { _RegisterRequests = value; }
        }


        #endregion

        #region Construction Functions

        public RegisterRequestsDAL()
        {
            _RegisterRequests = new RegisterRequests();
        }

        public RegisterRequestsDAL(int Id)
        {
            Db = new SOKNAEntities();
            _RegisterRequests = Db.RegisterRequests.Single(r => r.Id == Id);
        }

        public RegisterRequestsDAL(RegisterRequests Pa)
        {
            _RegisterRequests = Pa;
        }


        #endregion
        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.RegisterRequests.Add(_RegisterRequests);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.RegisterRequests.Remove(_RegisterRequests);
            Db.SaveChanges();
        }
        #endregion



        #region Business Function
        public static List<RegisterRequestsDAL> Get_RegisterRequestsList()
        {
            List<RegisterRequestsDAL> List = new List<RegisterRequestsDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.RegisterRequests.ToList();
                Res.ForEach(r => List.Add(new RegisterRequestsDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetRegisterRequestsComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.RegisterRequests.Select(r => new { Name = r.Person.FullName, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion
    }
}