using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDiary.API.Controllers
{
    [Route("UserProfiles")]
    [ConsoleLogger]
    [ExceptionFilter]
    public class UserProfilesController : ApiController //Controller
    {
        private readonly IUserService ups;

        public UserProfilesController()
        {
            ups = NinjectKernel.Kernel.Get<IUserService>();
        }

        // GET api/categories
        [HttpGet]
        public async Task<IEnumerable<UserProfileBO>> GetAllProfilesAsync()
        {
            return await ups.GetAllUserProfilesAsync();
        }

        // GET api/categories/1
        [HttpGet]
        [Authenticated]
        public async Task<UserProfileBO> GetProfileByIdAsync(int id)
        {
            return await ups.GetUserProfileAsync(id);
        }

        // POST api/categories 
        [HttpPost]
        [Authenticated]
        public async Task CreateProfileAsync(UserProfileBO profile)
        {
            await ups.CreateUserProfileAsync(profile);
        }

        // PUT api/categories/1 
        [HttpPut]
        [Authenticated]
        public async Task UpdateProfileAsync(UserProfileBO profile)
        {
            await ups.UpdateUserProfileAsync(profile);
        }

        // DELETE api/categories/1 
        [HttpDelete]
        [Authenticated]
        public async Task DeleteProfileByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            await ups.DeleteUserProfileAsync((int)id);
        }
    }
}