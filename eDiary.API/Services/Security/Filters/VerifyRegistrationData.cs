using eDiary.API.Models.BusinessObjects;
using System;
using System.Linq;
using System.Web.Mvc;

namespace eDiary.API.Services.Security.Filters
{
    public class VerifyRegistrationData : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var param = filterContext.ActionParameters.SingleOrDefault(p => p.Value is RegistrationData);

            if (!(param.Value is RegistrationData data)) throw new ArgumentNullException(nameof(data));
            if (data.FirstName == null) throw new ArgumentNullException(nameof(data.FirstName));
            //if (data.Username == null) throw new ArgumentNullException(nameof(data.Username));
            if (data.Password == null) throw new ArgumentNullException(nameof(data.Password));
            if (data.Email == null) throw new ArgumentNullException(nameof(data.Email));
        }
    }
}
