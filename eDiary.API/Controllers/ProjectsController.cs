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
    [RoutePrefix("projects")]
    [Authenticated]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectService ps;

        public ProjectsController()
        {
            ps = NinjectKernel.Kernel.Get<IProjectService>();
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectCard>> GetAllProjects()
        {
            return await ps.GetAllProjectsAsync();
        }
        
        [HttpGet]
        public async Task<ProjectCard> GetProjectById(int? id)
        {
            Validate(id);
            return await ps.GetProjectCardAsync((int)id);
        }
        
        [HttpPost]
        public async Task CreateProject(ProjectCard project)
        {
            Validate(project);
            await ps.CreateProjectAsync(project);
        }
        
        [HttpPut]
        public async Task UpdateProject(ProjectCard project)
        {
            Validate(project);
            await ps.UpdateProjectAsync(project);
        }
        
        [HttpDelete]
        public async Task DeleteProjectById(int? id)
        {
            Validate(id);
            await ps.DeleteProjectAsync((int)id);
        }
    }
}
