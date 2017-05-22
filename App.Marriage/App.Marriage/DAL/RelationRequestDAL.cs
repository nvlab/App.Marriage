using App.Marriage.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.DAL
{
    public class RelationRequestDAL
    {

        #region Properties

        private SOKNAEntities Db;
        private RelationRequest _RelationRequest;
        public RelationRequest RelationRequest
        {
            get { return _RelationRequest; }
            set { _RelationRequest = value; }
        }


        #endregion

        #region Construction Functions

        public RelationRequestDAL()
        {
            _RelationRequest = new RelationRequest();
        }

        public RelationRequestDAL(int Id)
        {
            Db = new SOKNAEntities();
            _RelationRequest = Db.RelationRequest.Single(r => r.Id == Id);
        }

        public RelationRequestDAL(RelationRequest Pa)
        {
            _RelationRequest = Pa;
        }


        #endregion
        #region Operation Main Functions

        public void Create()
        {
            using (var db = new SOKNAEntities())
            {
                db.RelationRequest.Add(_RelationRequest);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            Db.SaveChanges();
        }

        public void Delete()
        {
            Db.RelationRequest.Remove(_RelationRequest);
            Db.SaveChanges();
        }
        #endregion



        #region Business Function
        public static List<RelationRequestDAL> GetRelationRequestList()
        {
            List<RelationRequestDAL> List = new List<RelationRequestDAL>();
            using (var db = new SOKNAEntities())
            {
                var Res = db.RelationRequest.ToList();
                Res.ForEach(r => List.Add(new RelationRequestDAL(r)));

            }
            return List;
        }
        public static IEnumerable GetRelationRequestComboList()
        {
            using (var db = new SOKNAEntities())
            {
                var Res = db.RelationRequest.Select(r => new { Name = r.Id, Id = r.Id }).ToList();
                return Res;
            }

        }
        #endregion
    }
}