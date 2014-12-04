using System;
using System.Data;
using System.Collections.Generic;
using System.Security.Principal;
using DataLayer;

namespace BLL
{
    [Serializable()]
    public class EPIdentity : IIdentity
    {
        private bool _isAuthenticated;
        private string _name = string.Empty;
        private int _employeeId;
        private List<string> _roles = new List<string>();

        public string AuthenticationType
        {
            get { return "Forms"; }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int EmployeeId
        {
            get { return _employeeId; }
        }

        internal bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        internal static EPIdentity UnauthenticatedIdentity()
        {
            return new EPIdentity();
        }

        internal static EPIdentity GetIdentity(string username, string password)
        {
            EPIdentity identity = new EPIdentity();
            identity.Fetch(username, password);
            return identity;
        }

        private EPIdentity()
        {
        }

		private void Fetch(string username, string password)
		{
			SecurityManager.LoginData loginData = SecurityManager.AuthenticatedUser(username, password);
			
			_isAuthenticated = loginData.IsAuthenticated;
			_name = loginData.Name;			
			foreach (var role in loginData.Roles)
			{
				_roles.Add(RoleMapper.RoleCodeToRoleString(role));
			}			
			_employeeId = loginData.EmployeeId;
		}
    }
}