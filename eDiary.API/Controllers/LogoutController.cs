using eDiary.API.Services.Security.Interfaces;
using System.Net;
using System.Web.Mvc;

namespace eDiary.API.Controllers
{
    public class LogoutController : Controller
    {
        private readonly IIdentityService identity;

        public LogoutController(IIdentityService identity)
        {
            this.identity = identity;
        }

        // POST api/logout
        [HttpPost]
        public ActionResult Logout()
        {
            try
            {
                var x = identity.LogOutAsync();
                if(x.Code == Services.Security.ResultCode.Succeeded)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            catch (System.Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
