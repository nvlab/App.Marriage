using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using App.Marriage.DAL;
using App.Marriage.Models.UserMV;
using App.Marriage.Models.PersonMV;

namespace App.Marriage.Helpars
{
    public class UserHelpar
    {
        /// <summary>
        /// Get Cuurent User Id
        /// </summary>
        /// <returns></returns>
        public static int GetUserId()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                string UserName = HttpContext.Current.User.Identity.GetUserName();
                UserDAL user =new UserDAL(UserName);
                return user.Users.Id;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Get Cuurent User
        /// </summary>
        /// <returns></returns>
        public static UserViewModel GetUser()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                string UserName = HttpContext.Current.User.Identity.GetUserName();
                UserDAL user = new UserDAL(UserName);
                UserViewModel UserVM = new UserViewModel(user);
                return UserVM;
            }
            else
            {
                UserViewModel UserVM = new UserViewModel();
                return UserVM;
            }
        }
        /// <summary>
        /// Get Cuurent User Role
        /// </summary>
        /// <returns></returns>
        public static string GetUserRole()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                string UserName = HttpContext.Current.User.Identity.GetUserName();
                UserDAL user = new UserDAL(UserName);
                return user.Users.Roles.RoleName;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get Cuurent User Role
        /// </summary>
        /// <returns></returns>
        public static string GetUserType()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                string UserName = HttpContext.Current.User.Identity.GetUserName();
                UserDAL user = new UserDAL(UserName);
                return user.Users.UserType;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get Current User Permisson Can Do
        /// </summary>
        /// <returns></returns>
        public static bool CanDo(Permissons Perm)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                string UserName = HttpContext.Current.User.Identity.GetUserName();
                UserDAL user = new UserDAL(UserName);
                RolePermissionsDAL UserPerm = new RolePermissionsDAL(user.Users.Role_Id.GetValueOrDefault(), (int)Perm);
                if (UserPerm.RolePermissions != null)
                {
                    return UserPerm.RolePermissions.IsActive.GetValueOrDefault();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Get Cuurent User Id
        /// </summary>
        /// <returns></returns>
        public static PersonViewModel GetPerson()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                string UserName = HttpContext.Current.User.Identity.GetUserName();
                UserDAL user = new UserDAL(UserName);
                PersonViewModel Person = PersonViewModel.GetPersonByUser(user.Users.Id);
                return Person;
            }
            else
            {
                PersonViewModel Person = new PersonViewModel();
                return Person;
            }
        }
    }
    public enum Permissons
    {
        Users = 1,
        Persons = 2,
        Messages = 3,
        ChatRom = 4,
        QuationBank = 5,
        AcceptUser = 6,
        Role = 6,
    }
}