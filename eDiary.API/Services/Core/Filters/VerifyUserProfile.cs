using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Core.Filters
{
    public class VerifyUserProfile : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is UserProfileBO);

            if (!(param.Value is UserProfileBO profile)) throw new ArgumentNullException(nameof(profile));
            if (profile.FirstName == null) throw new ArgumentNullException(nameof(profile.FirstName));
            if (profile.Email == null) throw new ArgumentNullException(nameof(profile.Email));
        }
    }
}
