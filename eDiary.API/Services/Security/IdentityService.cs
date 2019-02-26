using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eDiary.API.Services.Security
{
    public class IdentityService : IIdentityService
    {
        private readonly ICryptographyService cs;
        private readonly IUnitOfWork uow;

        public IdentityService()
        {
            cs = NinjectKernel.Kernel.Get<ICryptographyService>();
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }
        
        public async Task<string> AuthenticateAsync(AuthenticationData data)
        {
            Validate.NotNull(data, "Authentication data");
            string enc = cs.EncryptPassword(data.Password);

            var pas = (await uow.AppUserRepository.GetByConditionAsync(x => x.Username == data.Username)).FirstOrDefault();
            if (pas == null) throw new Exception("User not found");

            if (enc != pas.PasswordHash) throw new Exception("Passwords are not match");

            return "some token";    // TODO: Implement
        }
        
        public async Task<(string username, string token)> RegisterAsync(RegistrationData data)
        {
            Validate.NotNull(data, "Registration data");

            {
                var temp = (await uow.UserProfileRepository.GetByConditionAsync(x => x.Email == data.Email)).FirstOrDefault();
                if (temp != null) throw new Exception("Email already exists");
            }

            var enc = cs.EncryptPassword(data.Password);

            var user = new Models.Entities.AppUser
            {
                Username = "undefined",
                PasswordHash = enc,
                UserProfile = new Models.Entities.UserProfile
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email
                }
            };

            await uow.AppUserRepository.CreateAsync(user);
            
            user.Username = cs.EncryptSHA256(user.UserProlifeId.ToString());

            uow.AppUserRepository.Update(user);

            return (user.Username, "some token");   // TODO: Implement
        }

        public async Task LogOutAsync()
        {
            throw new NotImplementedException();
        }
        
        public async Task ChangePasswordAsync(ChangePasswordData data)
        {
            Validate.NotNull(data, "Change password data");
            // TODO: Add email notification about password change
            throw new NotImplementedException();
        }

        public async Task ResetPasswordAsync()
        {
            // TODO: Add email notification about password reset
            throw new NotImplementedException();
        }
    }
}
