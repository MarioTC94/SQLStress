using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace SQLStress.Web.Commons.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SecurityFilterAccess : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.UrlReferrer == null || filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "MaliciousRequest" }));
        }
    }
}