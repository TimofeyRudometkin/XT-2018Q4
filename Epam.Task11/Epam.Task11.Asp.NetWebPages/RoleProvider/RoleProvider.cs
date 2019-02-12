using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.Task11.Asp.NetWebPages.RoleProvider
{
    public class MyRoleProvider : System.Web.Security.RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "!Timofey")
            {
                return true;
            }
            if (roleName == "User")
            {
                return true;
            }
            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            switch (username)
            {
                case "!Timofey":
                    return new[] { "Admins", "User" };
                default:
                    return new[] { "User" };
            }
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        #region NotImplemented

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}