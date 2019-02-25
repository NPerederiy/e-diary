using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Validation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eDiary.API.Services.Security
{
    public class IdentityService : IIdentityService
    {
        private readonly ICryptographyService cs;
        private readonly IUnitOfWork uow;

        public IdentityService(ICryptographyService cs, IUnitOfWork uow)
        {
            this.cs = cs;
            this.uow = uow;
        }
        
        public async Task<IOperationResult> AuthenticateAsync(AuthenticationData data)
        {
            Validate.NotNull(data, "Authentication data");
            string enc;

            //try
            //{
                enc = cs.EncryptPassword(data.Password).Content;
            //}
            //catch (SecurityException ex)
            //{
            //    if (ex.ParamName == "password")
            //    {
            //        return new OperationResult(ResultCode.IncorrectPassword);
            //    }
            //    else
            //    {
            //        return new OperationResult(ResultCode.EncryptionError);
            //    }
            //}
            //catch (Exception)
            //{
            //    return new OperationResult(ResultCode.EncryptionError);
            //}

            var pas = (await uow.AppUserRepository.GetByConditionAsync(x => x.Username == data.Username)).FirstOrDefault();

            if (pas == null) return new OperationResult(ResultCode.UserNotFound); 

            if (enc == pas.PasswordHash)
            {
                return new OperationResult(ResultCode.Succeeded);
            }
            else
            {
                return new OperationResult(ResultCode.PasswordsNotMatch);
            }
        }
        
        public async Task<IOperationResult> RegisterAsync(RegistrationData data)
        {
            Validate.NotNull(data, "Registration data");
            //{
            //    var temp = (await uow.AppUserRepository.GetByConditionAsync(x => x.Username == data.Username)).FirstOrDefault();
            //    if (temp != null) return new OperationResult(ResultCode.UsernameAlreadyExists);
            //}
            {
                var temp = (await uow.UserProfileRepository.GetByConditionAsync(x => x.Email == data.Email)).FirstOrDefault();
                if (temp != null) return new OperationResult(ResultCode.EmailAlreadyExists);
            }

            var enc = "";
            //try
            //{
                enc = cs.EncryptPassword(data.Password).Content;
            //}
            //catch (SecurityException ex)
            //{
            //    if (ex.ParamName == "password")
            //    {
            //        return new OperationResult(ResultCode.IncorrectPassword);
            //    }
            //    else
            //    {
            //        return new OperationResult(ResultCode.EncryptionError);
            //    }
            //}
            //catch (Exception)
            //{
            //    return new OperationResult(ResultCode.EncryptionError);
            //}

            var user = new Models.Entities.AppUser
            {
                Username = "undefined" /*data.Username*/,
                PasswordHash = enc,
                UserProfile = new Models.Entities.UserProfile
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email
                }
            };

            await uow.AppUserRepository.CreateAsync(user);
            
            user.Username = cs.EncryptSHA256(user.UserProlifeId.ToString()).Content;

            uow.AppUserRepository.Update(user);

            return new OperationResult(ResultCode.Succeeded, "", user.Username);
        }

        public async Task<IOperationResult> LogInAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IOperationResult> LogOutAsync()
        {
            throw new NotImplementedException();
        }
        
        public async Task<IOperationResult> ChangePasswordAsync(ChangePasswordData data)
        {
            Validate.NotNull(data, "Change password data");
            // TODO: Add email notification about password change
            throw new NotImplementedException();
        }

        public async Task<IOperationResult> ResetPasswordAsync()
        {
            // TODO: Add email notification about password reset
            throw new NotImplementedException();
        }
    }
}
