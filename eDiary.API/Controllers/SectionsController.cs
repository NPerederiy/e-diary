using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [JwtAuthentication]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SectionsController : ApiController
    {
        private readonly ISectionService ss;

        public SectionsController()
        {
            ss = NinjectKernel.Kernel.Get<ISectionService>();
        }
        
        [HttpGet]
        public async Task<IEnumerable<SectionCard>> GetAllSectionsAsync()
        {
            return await ss.GetAllSectionsAsync();
        }
        
        [HttpGet]
        public async Task<SectionCard> GetSectionByIdAsync(int? id)
        {
            Validate(id);
            return await ss.GetSectionAsync((int)id);
        }
        
        [HttpPost]
        public async Task CreateSectionAsync(SectionCard section)
        {
            Validate(section);
            await ss.CreateSectionAsync(section);
        }
        
        [HttpPut]
        public async Task UpdateSectionAsync(SectionCard section)
        {
            Validate(section);
            await ss.UpdateSectionAsync(section);
        }
        
        [HttpDelete]
        public async Task DeleteSectionByIdAsync(int? id)
        {
            await ss.DeleteSectionAsync((int)id);
        }
    }
}
