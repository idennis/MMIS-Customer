using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

    public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Put your authorisation check here.
            return httpContext.Session["Username"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Put your redirect to login controller here.
            filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary(new { controller = "Login", action = "Index" }));
        }
    }



