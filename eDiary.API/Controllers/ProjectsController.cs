using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [RoutePrefix("projects")]
    [JwtAuthentication]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectService ps;
        private readonly IIdentityService iis;

        public ProjectsController()
        {
            ps = NinjectKernel.Kernel.Get<IProjectService>();
            iis = NinjectKernel.Kernel.Get<IIdentityService>();
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectCard>> GetAllProjects()
        {
            return await ps.GetProjectsByProfileIdAsync(iis.GetProfileIdFromTokenPayload(GetTokenFromHeader()));
        }
        
        [HttpGet]
        public async Task<ProjectCard> GetProjectById(int? id)
        {
            Services.Validation.Validate.NotNull(id, "Project id");
            return await ps.GetProjectCardAsync((int)id);
        }

        [HttpPost]
        public async Task<int> CreateProject(CreateProjectData project)
        {
            Services.Validation.Validate.NotNull(project.Name, "Project name");
            var projectId = await ps.CreateProjectAsync(project.Name, project.CategoryId, iis.GetProfileIdFromTokenPayload(GetTokenFromHeader()));
            return projectId;
        }
        
        [HttpPut]
        public async Task UpdateProject(UpdateProjectData project)
        {
            Services.Validation.Validate.NotNull(project.ProjectId, "Project id");
            Services.Validation.Validate.NotNull(project.Name, "Project name");

            await ps.UpdateProjectAsync(project.ProjectId, project.Name, project.CategoryId);
        }
        
        [HttpDelete]
        public async Task DeleteProjectById(int? id)
        {
            Services.Validation.Validate.NotNull(id, "Project id");
            await ps.DeleteProjectAsync((int)id);
        }

        private string GetTokenFromHeader()
        {
            return Request.Headers.GetValues("Authorization").First().Split(' ')[1];
        }
    }
}
