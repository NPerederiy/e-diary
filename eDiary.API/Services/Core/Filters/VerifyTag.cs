using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Core.Filters
{
    public class VerifyTag : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is TagBO);

            if (!(param.Value is TagBO profile)) throw new ArgumentNullException(nameof(profile));
            if (profile.Name == null) throw new ArgumentNullException(nameof(profile.Name));
        }
    }
}
