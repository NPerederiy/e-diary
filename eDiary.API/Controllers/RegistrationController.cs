using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [RoutePrefix("Registration")]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "POST")]
    public class RegistrationController : ApiController
    {
        private readonly IIdentityService identity;

        public RegistrationController()
        {
            identity = NinjectKernel.Kernel.Get<IIdentityService>();
        }

        [HttpPost]
        public async Task<(string username, string token)> RegisterAsync(RegistrationData data)
        {
            Validate(data);
            var x = await identity.RegisterAsync(data);
            if (x.token == null) throw new System.Exception("Authentication token wasn't received.");
            if (x.username == null) throw new System.Exception("Username wasn't generated.");
            return x;
        }
    }
}
