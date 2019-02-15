using System.Threading.Tasks;

namespace eDiary.API.Services.Security.Interfaces
{
    public interface IIdentityService
    {
        Task<IOperationResult> Authenticate(string login, string passHash);
        Task<IOperationResult> Register(string firstName, string lastName, string passHash, string username, string email);
        Task<IOperationResult> LogIn();
        IOperationResult LogOut();
        Task<IOperationResult> ChangePassword(string currentPassword, string newPassword);
        Task<IOperationResult> ResetPassword();
    }
}
