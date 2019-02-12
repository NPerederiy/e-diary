using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace eDiary.API.Filters
{
    public class Authenticated : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                //filterContext.Result = new RedirectToRouteResult( // RedirectResult("/Content/ExceptionFound.html");
                //    new System.Web.Routing.RouteValueDictionary {
                //    { "controller", "Account" }, { "action", "Login" }
                //});
            }
        }
    }
}
