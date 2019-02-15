using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Security.Exceptions;
using eDiary.API.Services.Security.Interfaces;
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

        public async Task<IOperationResult> Authenticate(string login, string password)
        {
            if (login == null) return new OperationResult(ResultCode.IncorrectUsername);
            if (password == null) return new OperationResult(ResultCode.IncorrectPassword);
            var enc = "";

            try
            {
                enc = cs.EncryptPassword(password).Content;
            }
            catch (SecurityException ex)
            {
                if (ex.ParamName == "password")
                {
                    return new OperationResult(ResultCode.IncorrectPassword);
                }
                else
                {
                    return new OperationResult(ResultCode.EncryptionError);
                }
            }
            catch (Exception)
            {
                return new OperationResult(ResultCode.EncryptionError);
            }

            var pas = (await uow.AppUserRepository.GetByConditionAsync(x => x.Username == login)).FirstOrDefault();

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

        public async Task<IOperationResult> Register(string firstName, string lastName, string password, string username, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName)) return new OperationResult(ResultCode.IncorrectFirstName);
            if (string.IsNullOrWhiteSpace(username)) return new OperationResult(ResultCode.IncorrectUsername);
            if (string.IsNullOrWhiteSpace(password)) return new OperationResult(ResultCode.IncorrectPassword);
            if (string.IsNullOrWhiteSpace(email)) return new OperationResult(ResultCode.IncorrectEmail);

            {
                var temp = (await uow.AppUserRepository.GetByConditionAsync(x => x.Username == username)).FirstOrDefault();
                if (temp != null) return new OperationResult(ResultCode.UsernameAlreadyExists);
            }
            {
                var temp = (await uow.UserProfileRepository.GetByConditionAsync(x => x.Email == email)).FirstOrDefault();
                if (temp != null) return new OperationResult(ResultCode.EmailAlreadyExists);
            }

            var enc = "";
            try
            {
                enc = cs.EncryptPassword(password).Content;
            }
            catch (SecurityException ex)
            {
                if (ex.ParamName == "password")
                {
                    return new OperationResult(ResultCode.IncorrectPassword);
                }
                else
                {
                    return new OperationResult(ResultCode.EncryptionError);
                }
            }
            catch (Exception)
            {
                return new OperationResult(ResultCode.EncryptionError);
            }

            await uow.AppUserRepository.CreateAsync(new Models.Entities.AppUser
            {
                Username = username,
                PasswordHash = enc,
                UserProfile = new Models.Entities.UserProfile
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            });

            return new OperationResult(ResultCode.Succeeded);
        }

        public async Task<IOperationResult> LogIn()
        {
            throw new NotImplementedException();
        }

        public IOperationResult LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<IOperationResult> ChangePassword(string currentPassword, string newPassword)
        {
            // TODO: Add email notification about password change
            throw new NotImplementedException();
        }

        public async Task<IOperationResult> ResetPassword()
        {
            // TODO: Add email notification about password reset
            throw new NotImplementedException();
        }
    }
}
