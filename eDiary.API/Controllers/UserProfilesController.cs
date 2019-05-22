using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [Route("UserProfiles")]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserProfilesController : ApiController
    {
        private readonly IUserService ups;

        public UserProfilesController()
        {
            ups = NinjectKernel.Kernel.Get<IUserService>();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<UserProfileBO>> GetAllProfilesAsync()
        {
            return await ups.GetAllUserProfilesAsync();
        }
        
        [HttpGet]
        [JwtAuthentication]
        public async Task<UserProfileBO> GetProfileByIdAsync(int? id)
        {
            Validate(id);
            return await ups.GetUserProfileAsync((int)id);
        }
        
        [HttpPost]
        [JwtAuthentication]
        public async Task CreateProfileAsync(UserProfileBO profile)
        {
            Validate(profile);
            await ups.CreateUserProfileAsync(profile);
        }
        
        [HttpPut]
        [JwtAuthentication]
        public async Task UpdateProfileAsync(UserProfileBO profile)
        {
            Validate(profile);
            await ups.UpdateUserProfileAsync(profile);
        }
        
        [HttpDelete]
        [JwtAuthentication]
        public async Task DeleteProfileByIdAsync(int? id)
        {
            Validate(id);
            await ups.DeleteUserProfileAsync((int)id);
        }
    }
}