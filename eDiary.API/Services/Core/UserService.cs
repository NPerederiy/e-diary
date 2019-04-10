using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities = eDiary.API.Models.Entities;

namespace eDiary.API.Services.Core
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<IEnumerable<UserProfileBO>> GetAllUserProfilesAsync()
        {
            var profiles = await uow.UserProfileRepository.GetAllAsync();
            return ConvertToBusinessObjects(profiles);
        }

        public async Task<UserProfileBO> GetUserProfileAsync(int id)
        {
            return new UserProfileBO(await FindProfileAsync(x => x.Id == id));
        }
        
        public async Task CreateUserProfileAsync(UserProfileBO profile)
        {
            Validate.NotNull(profile, "User profile");

            var p = new Entities.UserProfile
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email         
            };

            await uow.UserProfileRepository.CreateAsync(p);
        }
        
        public async Task UpdateUserProfileAsync(UserProfileBO profile)
        {
            Validate.NotNull(profile, "User profile");
            var p = await FindProfileAsync(x => x.Id == profile.ProfileId);

            p.FirstName = profile.FirstName;
            p.LastName = profile.LastName;
            p.Email = profile.Email;
            //p.ProfileImage = profile.ProfileImage;    // TODO: implement this

            uow.UserProfileRepository.Update(p);
        }

        public async Task DeleteUserProfileAsync(int id)
        {
            uow.UserProfileRepository.Delete(await FindProfileAsync(x => x.Id == id));
        }

        private async Task<Entities.UserProfile> FindProfileAsync(Expression<Func<Entities.UserProfile, bool>> condition)
        {
            return await FindEntityAsync(uow.UserProfileRepository, condition);
        }

        private static List<UserProfileBO> ConvertToBusinessObjects(IEnumerable<Entities.UserProfile> profiles)
        {
            var userProfiles = new List<UserProfileBO>();
            foreach (var p in profiles)
            {
                userProfiles.Add(new UserProfileBO(p));
            }
            return userProfiles;
        }
    }
}
