using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserProfileBO>> GetAllUserProfilesAsync();
        Task<UserProfileBO> GetUserProfileAsync(int id);
        Task CreateUserProfileAsync(UserProfileBO profile);
        Task UpdateUserProfileAsync(UserProfileBO profile);
        Task DeleteUserProfileAsync(int id);
    }
}
