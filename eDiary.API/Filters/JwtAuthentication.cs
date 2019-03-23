using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace eDiary.API.Filters
{
    public class JwtAuthentication : FilterAttribute, IAuthenticationFilter
    {
        //public void OnAuthentication(AuthenticationContext filterContext)
        //{
        //    var user = filterContext.HttpContext.User;
        //    if (user == null || !user.Identity.IsAuthenticated)
        //    {
        //        filterContext.Result = new HttpUnauthorizedResult();
        //    }
        //}

        //public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        //{
        //    var user = filterContext.HttpContext.User;
        //    if (user == null || !user.Identity.IsAuthenticated)
        //    {
        //        filterContext.Result = new HttpUnauthorizedResult();
        //        //filterContext.Result = new RedirectToRouteResult( // RedirectResult("/Content/ExceptionFound.html");
        //        //    new System.Web.Routing.RouteValueDictionary {
        //        //    { "controller", "Account" }, { "action", "Login" }
        //        //});
        //    }
        //}

        public string Realm { get; set; }
        public override bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
                return;

            if (string.IsNullOrEmpty(authorization.Parameter))
                throw new Exception("Missing Jwt Token");

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);
            
            if (principal == null)
                throw new Exception("Invalid token");

            else
                context.Principal = principal;
        }



        //private static bool ValidateToken(string token, out string username)
        //{
        //    username = null;
        //    var identityService = NinjectKernel.Kernel.Get<Services.Security.Interfaces.IIdentityService>();

        //    var simplePrinciple = identityService.GetPrincipal(token);
        //    var identity = simplePrinciple?.Identity as ClaimsIdentity;

        //    if (identity == null)
        //        return false;

        //    if (!identity.IsAuthenticated)
        //        return false;

        //    var usernameClaim = identity.FindFirst(ClaimTypes.Name);
        //    username = usernameClaim?.Value;

        //    if (string.IsNullOrEmpty(username))
        //        return false;

        //    // More validate to check whether username exists in system

        //    return true;
        //}

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            var identityService = NinjectKernel.Kernel.Get<Services.Security.Interfaces.IIdentityService>();
            if (identityService.ValidateAccessToken(token, out string username))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                    // Add more claims if needed: Roles, ...
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            context.ChallengeWith("Bearer", parameter);
        }
    }
}
