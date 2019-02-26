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
        /// <returns>Returns an authentication token</returns>
        Task<string> AuthenticateAsync(AuthenticationData data);

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="data">User's registration data</param>
        /// <returns>Returns a (string, string) tuple, where the first field is a username and the second is an authentication token</returns>
        Task<(string username, string token)> RegisterAsync(RegistrationData data);

        Task LogOutAsync();

        Task ChangePasswordAsync(ChangePasswordData data);

        Task ResetPasswordAsync();
    }
}
