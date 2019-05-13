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
            Services.Validation.Validate.NotNull(id, "Section id");
            return await ss.GetSectionAsync((int)id);
        }
        
        [HttpPost]
        public async Task<int> CreateSectionAsync(CreateSectionData section)
        {
            Services.Validation.Validate.NotNull(section);
            Services.Validation.Validate.NotNull(section.Name, "Section name");
            Services.Validation.Validate.NotNull(section.ProjectId, "Project id");
            return await ss.CreateSectionAsync(section.Name, section.ProjectId);
        }
        
        [HttpPut]
        public async Task UpdateSectionAsync(UpdateSectionData section)
        {
            Services.Validation.Validate.NotNull(section);
            Services.Validation.Validate.NotNull(section.Name, "Section name");
            Services.Validation.Validate.NotNull(section.SectionId, "Section id");
            Services.Validation.Validate.NotNull(section.ProjectId, "Project id");
            await ss.UpdateSectionAsync(section.SectionId, section.Name, section.ProjectId);
        }
        
        [HttpDelete]
        public async Task DeleteSectionByIdAsync(int? id)
        {
            await ss.DeleteSectionAsync((int)id);
        }
    }
}
