using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Web;

namespace BLL
{
    public class SiteMapRoleProvider : XmlSiteMapProvider
    {
        public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        {
            if (node.Roles == null || node.Roles.Count == 0 || node.Roles.Contains("*"))
            {
                return true;
            }

			if (HttpContext.Current.Session["CurrentPrincipal"] is EPPrincipal)
            {
				EPPrincipal principal = HttpContext.Current.Session["CurrentPrincipal"] as EPPrincipal;
                foreach (string role in node.Roles)
                {
                    if (principal.IsInRole(role))
                        return true;
                }
            }

            return false;
        }
    }
}