using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BadmintonWPFApp
{
    public class AuthorizeToAccessMethods
    {
        private readonly RoleObject _roleObject;

        public AuthorizeToAccessMethods()
        {
            _roleObject = new RoleObject();
        }

        public bool AuthorizeBaseOnRole(User user, bool Admin = false, bool Manager = false, bool Staff = false, bool Customer = false)
        {
            var rolesOfUser = user.Roles.ToList();
            var allRoles = _roleObject.GetAllRoles().ToDictionary(x => x.RoleName, x => x);

            if (Admin && !rolesOfUser.Contains(allRoles["Admin"]))
            {
                return false;
            }
            if (Manager && !rolesOfUser.Contains(allRoles["Manager"]))
            {
                return false;
            }
            if (Staff && !rolesOfUser.Contains(allRoles["Staff"]))
            {
                return false;
            }
            if (Customer && !rolesOfUser.Contains(allRoles["Customer"]))
            {
                return false;
            }
            return true;
        }
        //Usage
        //public void onlyForAdmin()
        //{
        //    if (!AuthorizeBaseOnRole(Properties.Settings.Default.User, admin: true)) return;
        //}
    }
}
