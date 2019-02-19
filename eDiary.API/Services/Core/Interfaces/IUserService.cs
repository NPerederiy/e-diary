using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserProfileBO>> GetAllUserProfilesAsync();
        Task<UserProfileBO> GetUserProfileAsync(int id);
        void CreateUserProfileAsync(UserProfileBO profile);
        void UpdateUserProfileAsync(UserProfileBO profile);
        void DeleteUserProfileAsync(int id);
    }
}
