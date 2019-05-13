using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [JwtAuthentication]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProjectPageController : ApiController
    {
        private readonly ISectionService ss;

        public ProjectPageController()
        {
            ss = NinjectKernel.Kernel.Get<ISectionService>();
        }

        [HttpGet]
        public async Task<IEnumerable<SectionCard>> GetSectionByProjectIdAsync(int? id)
        {
            Services.Validation.Validate.NotNull(id, "Project id");
            return await ss.GetProjectSectionsAsync((int)id);
        }
    }
}
