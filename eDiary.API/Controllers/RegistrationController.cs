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
    public class RegistrationController : ApiController
    {
        private readonly IIdentityService identity;

        public RegistrationController()
        {
            identity = NinjectKernel.Kernel.Get<IIdentityService>();
        }
        
        [HttpPost]
        public async Task<string>/*<ActionResult>*/ RegisterAsync(RegistrationData data)
        {
            Validate(data);
            var x = await identity.RegisterAsync(data);
            //if(x.Code == ResultCode.Succeeded)
            //{
            return x.Content;
                //return new HttpStatusCodeResult(HttpStatusCode.OK);
            //}
            //else
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, x.Message);
            //}
        }
    }
}
