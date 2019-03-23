using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [RoutePrefix("Token")]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "POST")]
    public class TokenController : ApiController
    {
        private readonly IIdentityService identity;

        public TokenController()
        {
            identity = NinjectKernel.Kernel.Get<IIdentityService>();
        }

        [HttpPost]
        public /*async*/ /*Task<*/AuthTokens/*> */GetNewTokens(string refreshToken)
        {
            var headers = Request.Headers;
            string access = null;
            if (headers.Contains("token"))
            {
                access = headers.GetValues("token").First();
            }
            if (access == null) throw new System.Exception("Access token wasn't received.");

            var payload = TokenPayload.GetPayload(access);
            



            Validate(refreshToken);
            var x = /*await*/ new AuthTokens("",""); //identity.GenerateTokens();
            if (x == null) throw new System.Exception("Tokens weren't generated.");
            return x;
        }
    }
}
