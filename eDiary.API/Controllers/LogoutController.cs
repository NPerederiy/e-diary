using eDiary.API.Filters;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDiary.API.Controllers
{
    [Authenticated]
    [ConsoleLogger]
    [ExceptionFilter]
    public class LogoutController : ApiController
    {
        private readonly IIdentityService identity;

        public LogoutController()
        {
            identity = NinjectKernel.Kernel.Get<IIdentityService>();
        }
        
        [HttpPost]
        public async Task/*<ActionResult>*/ LogoutAsync()
        {
            //try
            //{
                var x = await identity.LogOutAsync();
                //if(x.Code == Services.Security.ResultCode.Succeeded)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.OK);
                //}
            //}
            //catch (System.Exception ex)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            //}
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
