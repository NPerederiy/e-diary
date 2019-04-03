using eDiary.API.Models.BusinessObjects;
using System.Threading.Tasks;

namespace eDiary.API.Services.Core.Interfaces
{
    public interface ISettingsService
    {
        Task<UserSettingsBO> GetUserSettingsByProfileIdAsync(int id);
        Task UpdateSettingsAsync(UserSettingsBO profile);
    }
}
