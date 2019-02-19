using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Security.Filters
{
    public class VerifyAuthenticationData : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is AuthenticationData);

            if (!(param.Value is AuthenticationData data)) throw new ArgumentNullException(nameof(data));
            if (data.Username == null) throw new ArgumentNullException(nameof(data.Username));
            if (data.Password == null) throw new ArgumentNullException(nameof(data.Password));
        }
    }
}
