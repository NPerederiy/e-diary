using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;
using System.Threading.Tasks;

namespace eDiary.API.Services.Core
{
    public class SettingsService : BaseService, ISettingsService
    {
        private readonly IUnitOfWork uow;

        public SettingsService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<UserSettingsBO> GetUserSettingsByProfileIdAsync(int id)
        {
            return new UserSettingsBO(await FindEntityAsync(uow.UserSettingsRepository, x => x.UserId == id));
        }

        public async Task UpdateSettingsAsync(UserSettingsBO settings)
        {
            Validate.NotNull(settings, "Settings");
            var s = await FindEntityAsync(uow.UserSettingsRepository, x => x.Id == settings.SettingsId);

            s.LanguageId = (await FindEntityAsync(uow.LanguageRepository, x => x.ShortCode == settings.LanguageCode)).Id;

            uow.UserSettingsRepository.Update(s);
        }
    }
}
