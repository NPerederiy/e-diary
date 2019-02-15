using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Security;
using eDiary.API.Services.Security.Interfaces;
using System.Net;
using System.Web.Mvc;

namespace eDiary.API.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService identity;

        public LoginController(IIdentityService identity)
        {
            this.identity = identity;
        }

        // POST api/login 
        [HttpPost]
        public ActionResult Authenticate(AuthenticationData data)
        {
            var x = identity.Authenticate(data.Username, data.Password).Result;
            if (x.Code == ResultCode.Succeeded)
            {
                //HttpContext.Response.Cookies["id"].Value = "ca-4353w";
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, x.Message);
            }          
        }
    }
}
