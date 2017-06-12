using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Utils
{
    /// <summary>
    /// تحديد نوع النمط على الداتابيز
    /// </summary>
    public enum EnumType
    {
        Geneder, Education, RequestStatus, CatType, ArticalStatus, Artical, Quation, RelationStatus, RegisterRequestStatus
    }


    public enum RelationStatus{ Pending, NotAccepting, UnderStudy, Archive  }

    /// <summary>
    /// جنس الشخص
    /// </summary>
    public enum Gender
    {
        Male, Female
    }
    /// <summary>
    /// نوع المستخدم
    /// </summary>
    public enum UserType
    {
        Admin, Person, Guest
    }
    /// <summary>
    /// الحالةالاجتماعية
    /// </summary>
    public enum SocialStatus
    {
        Married, Single
    }
    /// <summary>
    /// حالة الطلب
    /// </summary>
    public enum RequestStatus
    {
        waiting, processing, UnderDecision, confirmed, rejected
    }
    /// <summary>
    /// نوع التصنيفات
    /// </summary>
    public enum CategoryType
    {
        Quation, Article
    }

    public static class GetEnumList
    {
        static public IEnumerable GetJGenderList()
        {
            return ((IEnumerable<Gender>)Enum.GetValues(typeof(Gender))).Select(c => new { Id = (int)c, Name = c.ToString() }).ToList();
        }
        static public IEnumerable GetUserTypeList()
        {
            return ((IEnumerable<UserType>)Enum.GetValues(typeof(UserType))).Select(c => new { Id = (int)c, Name = c.ToString() }).ToList();
        }
        static public IEnumerable GetSocialStatusList()
        {
            return ((IEnumerable<SocialStatus>)Enum.GetValues(typeof(SocialStatus))).Select(c => new { Id = (int)c, Name = c.ToString() }).ToList();
        }
        static public IEnumerable GetRequestStatusList()
        {
            return ((IEnumerable<RequestStatus>)Enum.GetValues(typeof(RequestStatus))).Select(c => new { Id = (int)c, Name = c.ToString() }).ToList();
        }
        static public IEnumerable GetCategoryTypeList()
        {
            return ((IEnumerable<CategoryType>)Enum.GetValues(typeof(CategoryType))).Select(c => new { Id = (int)c, Name = c.ToString() }).ToList();
        }

    }
}