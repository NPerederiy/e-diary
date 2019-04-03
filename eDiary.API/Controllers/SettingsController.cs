using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Core.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SettingsController : ApiController
    {
        private readonly ISettingsService ss;

        public SettingsController()
        {
            ss = NinjectKernel.Kernel.Get<ISettingsService>();
        }

        [HttpGet]
        public async Task<UserSettingsBO> GetSettingsByProfileIdAsync(int? id)
        {
            Validate(id);
            return await ss.GetUserSettingsByProfileIdAsync((int)id);
        }

        [HttpPut]
        public async Task UpdateSettingsAsync(UserSettingsBO settings)
        {
            Validate(settings);
            await ss.UpdateSettingsAsync(settings);
        }
        
    }
}
