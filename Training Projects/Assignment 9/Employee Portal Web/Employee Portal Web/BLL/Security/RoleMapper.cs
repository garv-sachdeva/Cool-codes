using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public static class RoleMapper
    {
        public static string RoleCodeToRoleString(string code)
        {
            switch (code)
            {
                case "A":
                    return "Admin";
                case "U":
                    return "User";
                default:
                    return null;
            }
        }
    }
}
