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
    [RoutePrefix("Authentication")]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "POST")]
    public class AuthenticationController: ApiController
    {
        private readonly IIdentityService identity;

        public AuthenticationController()
        {
            identity = NinjectKernel.Kernel.Get<IIdentityService>();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<AuthTokens> AuthenticateAsync(AuthenticationData data)
        {
            Validate(data);
            var token = await identity.AuthenticateAsync(data);
            if(token == null) throw new System.Exception("Tokens weren't generated.");
            return token;
        }
    }
}
