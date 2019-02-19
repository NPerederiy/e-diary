﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using eDiary.API.Services.Core.Filters;
using eDiary.API.Services.Core.Interfaces;

namespace eDiary.API.Services.Core
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<UserProfileBO>> GetAllUserProfilesAsync()
        {
            var profiles = await uow.UserProfileRepository.GetAllAsync();
            return ConvertToBusinessObjects(profiles);
        }

        public async Task<UserProfileBO> GetUserProfileAsync(int id)
        {
            return new UserProfileBO(await TryFindUserProfile(id));
        }

        [VerifyUserProfile]
        public async void CreateUserProfileAsync(UserProfileBO profile)
        {
            var p = new UserProfile
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email                
            };
            await uow.UserProfileRepository.CreateAsync(p);
        }

        [VerifyUserProfile]
        public async void UpdateUserProfileAsync(UserProfileBO profile)
        {
            var p = await TryFindUserProfile(profile.UserId);

            p.FirstName = profile.FirstName;
            p.LastName = profile.LastName;
            p.Email = profile.Email;
            //p.ProfileImage = profile.ProfileImage;    // TODO: implement this

            uow.UserProfileRepository.Update(p);
        }

        public async void DeleteUserProfileAsync(int id)
        {
            uow.UserProfileRepository.Delete(await TryFindUserProfile(id));
        }

        private async Task<UserProfile> TryFindUserProfile(int id)
        {
            var p = (await uow.UserProfileRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (p == null) throw new Exception("User profile not found");
            return p;
        }

        private static List<UserProfileBO> ConvertToBusinessObjects(IEnumerable<UserProfile> profiles)
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
