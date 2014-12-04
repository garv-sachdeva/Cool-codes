using System;
using System.Security.Principal;
using System.Web;

namespace BLL
{
    [Serializable()]
    public class EPPrincipal : IPrincipal
    {
        public EPPrincipal()
        {
            
        }

        public bool Login(string username, string password)
        {
            EPIdentity identity = EPIdentity.GetIdentity(username, password);
            if (identity.IsAuthenticated)
            {
				this._identity = identity;
            }

			return identity.IsAuthenticated;
        }

        public void Logout()
        {
            EPIdentity identity = EPIdentity.UnauthenticatedIdentity();
			this._identity = identity;
        }

        #region IPrincipal Members
        IIdentity _identity;

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public bool IsInRole(string role)
        {
           EPIdentity identity = (EPIdentity)this.Identity;
            return identity.IsInRole(role);
        }

        #endregion
    }
}