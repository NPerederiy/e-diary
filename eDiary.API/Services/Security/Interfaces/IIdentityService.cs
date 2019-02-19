using eDiary.API.Models.BusinessObjects;
using System.Threading.Tasks;

namespace eDiary.API.Services.Security.Interfaces
{
    public interface IIdentityService
    {
        Task<IOperationResult> AuthenticateAsync(AuthenticationData data);
        Task<IOperationResult> RegisterAsync(RegistrationData data);
        Task<IOperationResult> LogInAsync();
        Task<IOperationResult> LogOutAsync();
        Task<IOperationResult> ChangePasswordAsync(ChangePasswordData data);
        Task<IOperationResult> ResetPasswordAsync();
    }
}
