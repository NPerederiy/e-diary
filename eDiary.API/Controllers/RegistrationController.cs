using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Security;
using eDiary.API.Services.Security.Interfaces;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eDiary.API.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IIdentityService identity;

        public RegistrationController(IIdentityService identity)
        {
            this.identity = identity;
        }

        // POST api/registration 
        [HttpPost]
        public async Task<ActionResult> RegisterAsync(RegistrationData data)
        {
            var x = await identity.RegisterAsync(data);
            if(x.Code == ResultCode.Succeeded)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, x.Message);
            }
        }
    }
}
