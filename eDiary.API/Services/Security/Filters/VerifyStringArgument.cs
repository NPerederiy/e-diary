using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Security.Filters
{
    public class VerifyStringArgument : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is string);
            if (!(param.Value is string data)) throw new ArgumentNullException(nameof(data));
        }
    }
}
