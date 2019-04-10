using eDiary.API.Models.BusinessObjects;
using System.Threading.Tasks;

namespace eDiary.API.Services.Security.Interfaces
{
    public interface IIdentityService
    {
        /// <summary>
        /// Authenticates the user
        /// </summary>
        /// <param name="data">User's credentials</param>
        /// <returns>Returns authentication tokens</returns>
        Task<AuthTokens> AuthenticateAsync(AuthenticationData data);

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="data">User's registration data</param>
        /// <returns>Returns authentication tokens</returns>
        Task<AuthTokens> RegisterAsync(RegistrationData data);

        Task ChangePasswordAsync(ChangePasswordData data);

        Task ResetPasswordAsync();

        string GenerateAccessToken(Models.Entities.AppUser user);

        string GenerateRefreshToken();

        AuthTokens GenerateTokens(Models.Entities.AppUser user);

        bool ValidateAccessToken(string token, out string username, out string profileId);
    }
}
