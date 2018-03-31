using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SQLStress.Web.Commons.Security
{
    public class BillingWebAppAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
            else
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
        }
    }
}