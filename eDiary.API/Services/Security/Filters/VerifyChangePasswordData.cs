using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Security.Filters
{
    public class VerifyChangePasswordData : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is ChangePasswordData);

            if (!(param.Value is ChangePasswordData data)) throw new ArgumentNullException(nameof(data));
            if (data.CurrentPassword == null) throw new ArgumentNullException(nameof(data.CurrentPassword));
            if (data.NewPassword == null) throw new ArgumentNullException(nameof(data.NewPassword));
        }
    }
}
