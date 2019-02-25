using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDiary.API.Controllers
{
    [ConsoleLogger]
    [ExceptionFilter]
    public class LoginController : ApiController
    {
        private readonly IIdentityService identity;

        public LoginController()
        {
            identity = NinjectKernel.Kernel.Get<IIdentityService>();
        }
        
        [HttpPost]
        public async Task/*<ActionResult>*/ AuthenticateAsync(AuthenticationData data)
        {
            Validate(data);
            var x = await identity.AuthenticateAsync(data);
            //if (x.Code == ResultCode.Succeeded)
            //{
            //    //HttpContext.Response.Cookies["id"].Value = "ca-4353w";
            //    return new HttpStatusCodeResult(HttpStatusCode.OK);
            //}
            //else
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, x.Message);
            //}          
        }
    }
}
