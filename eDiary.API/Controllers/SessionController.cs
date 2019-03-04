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
    [RoutePrefix("Session")]
    [ConsoleLogger]
    [ExceptionFilter]

    [EnableCors(origins: "*", headers: "*", methods: "POST")]
    public class SessionController : ApiController
    {
        private readonly IIdentityService identity;

        public SessionController()
        {
            identity = NinjectKernel.Kernel.Get<IIdentityService>();
        }

        [HttpPost]
        [Route("Session/authenticate")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public async Task<string> AuthenticateAsync(AuthenticationData data)
        {
            Validate(data);
            var token = await identity.AuthenticateAsync(data);

            if (token == null) throw new System.Exception("Authentication token wasn't received.");

            return token;
        }   // HttpContext.Response.Cookies["id"].Value = "ca-4353w";

        [HttpPost]
        [Route("register")]
        public /*async Task<*/(string username, string token)/*>*/ RegisterAsync(RegistrationData data)
        {
            Validate(data);
            var x =/* await */identity.RegisterAsync(data).Result;
            if (x.token == null) throw new System.Exception("Authentication token wasn't received.");
            if (x.username == null) throw new System.Exception("Username wasn't generated.");
            return x;
        }

        [HttpPost]
        [Route("Session/logout")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        [Authenticated]
        public async Task LogoutAsync()
        {
            await identity.LogOutAsync();
        }
    }
}
