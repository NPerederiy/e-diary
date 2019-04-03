using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Microsoft.IdentityModel.Tokens;
using Ninject;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities = eDiary.API.Models.Entities;

namespace eDiary.API.Services.Security
{
    public class IdentityService : BaseService, IIdentityService
    {
        private readonly ICryptographyService cs;
        private readonly IUnitOfWork uow;
        private readonly IUserService ups;

        public IdentityService()
        {
            cs = NinjectKernel.Kernel.Get<ICryptographyService>();
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
            ups = NinjectKernel.Kernel.Get<IUserService>();
        }
        
        public async Task<AuthTokens> AuthenticateAsync(AuthenticationData data)
        {
            Validate.NotNull(data, "Authentication data");

            var user = await FindAppUserAsync(x => x.Username == data.Username);

            var enc = cs.EncryptPassword(data.Password);
            if (enc != user.PasswordHash) throw new Exception("Passwords are not match");

            return GenerateTokens(user);
        }
        
        public async Task<AuthTokens> RegisterAsync(RegistrationData data)
        {
            Validate.NotNull(data, "Registration data");
            Validate.NotNull(data.FirstName, "First name");
            Validate.NotNull(data.LastName, "Last name");
            Validate.NotNull(data.Email, "Email");
            Validate.NotNull(data.LanguageCode, "Language code");
            
            {
                var temp = (await uow.UserProfileRepository.GetByConditionAsync(x => x.Email == data.Email)).FirstOrDefault();
                if (temp != null) throw new Exception("Email already in use");
            }

            var language = await FindEntityAsync(uow.LanguageRepository, x => x.ShortCode == data.LanguageCode);

            var enc = cs.EncryptPassword(data.Password);

            var rootFolder = new Entities.Folder
            {
                Name = "Root",
                ParentFolderId = null
            };

            var settings = new Entities.UserSettings
            {
                LanguageId = language.Id,
                Folder = rootFolder
            };

            var profile = new Entities.UserProfile
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                UserSettings = new System.Collections.Generic.List<Entities.UserSettings> { settings }
            };

            var user = new Entities.AppUser
            {
                Username = "undefined",
                PasswordHash = enc,
                UserProfile = profile
            };

            await uow.AppUserRepository.CreateAsync(user);
            
            user.Username = cs.GenerateUsername();
            uow.AppUserRepository.Update(user);

            var tokens = GenerateTokens(user);

            var session = new Entities.Session
            {
                AppUserId = user.Id,
                Token = tokens.RefreshToken,
                CreatedAt = DateTime.UtcNow.ToLongTimeString()
            };

            await uow.SessionRepository.CreateAsync(session);

            return tokens; 
        }

        public AuthTokens GenerateTokens(Entities.AppUser user)
        {
            var refresh = GenerateRefreshToken();
            var access = GenerateAccessToken(user);
            return new AuthTokens(access, refresh);
        }

        public string GenerateAccessToken(Entities.AppUser user)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    },
                    expires: now.AddMinutes(AuthOptions.LIFETIME),
                    signingCredentials: new SigningCredentials(
                        AuthOptions.GetSymmetricSecurityKey(),
                        SecurityAlgorithms.HmacSha256
                    )
                );

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwt);
        }

        public string GenerateRefreshToken()
        {
            var token = cs.GenerateRefreshToken();
            var pin = "";    // TODO: Implement

            return cs.EncryptToken(token, pin);
        }

        public void ValidateRefreshToken(string token)
        {
            var key = new byte[64];
            var decrypted = cs.DecryptAES(token, key);
            if (" here should be a refresh token from DB " != decrypted)    // TODO: Implement
                throw new Exception("Refresh token is invalid.");
        }

        public bool ValidateAccessToken(string token, out string username)
        {
            username = null;

            var principal = GetPrincipal(token);

            if (!(principal.Identity is ClaimsIdentity identity))
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;
            var uname = username;
            var user = FindAppUserAsync(x => x.Username == uname).Result;
            if (user == null) return false;

            return true;
        }

        //public bool ValidateToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var validationParameters = new TokenValidationParameters
        //    {
        //        ValidateLifetime = true,
        //        ValidateAudience = true, 
        //        ValidateIssuer = true,   
        //        ValidIssuer = AuthOptions.ISSUER,
        //        ValidAudience = AuthOptions.AUDIENCE,
        //        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
        //    };

        //    IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        //    return true;
        //}

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

        private async Task<Entities.AppUser> FindAppUserAsync(Expression<Func<Entities.AppUser, bool>> condition)
        {
            return await FindEntityAsync(uow.AppUserRepository, condition);
        }

        private ClaimsPrincipal GetPrincipal(string token)
        {
            //try
            //{
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!(tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken))
                return null;

            var validationParameters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = AuthOptions.ISSUER,
                ValidAudience = AuthOptions.AUDIENCE,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
            };

            return tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return null;
            //}
        }
    }
}
