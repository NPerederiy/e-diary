using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eDiary.API.Controllers
{
    [RoutePrefix("projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService ps;

        public ProjectsController(IProjectService ps)
        {
            this.ps = ps;
        }

        // GET api/projects
        [HttpGet]
        [Authenticated]
        public async Task<IEnumerable<ProjectCard>> GetAllProjects()
        {
            return await ps.GetAllProjectsAsync();
        }

        // GET api/projects/1
        [HttpGet]
        [Authenticated]
        public async Task<ProjectCard> GetProjectById(int id)
        {
            return await ps.GetProjectCardAsync(id);
        }

        // POST api/projects 
        [HttpPost]
        [Authenticated]
        public void CreateProject(ProjectCard project)
        {
            ps.CreateProjectAsync(project);
        }

        // PUT api/projects/1 
        [HttpPut]
        [Authenticated]
        public void UpdateProject(ProjectCard project)
        {
            ps.UpdateProjectAsync(project);
        }

        // DELETE api/projects/1 
        [HttpDelete]
        [Authenticated]
        public void DeleteProjectById(int id)
        {
            ps.DeleteProjectAsync(id);
        }
    }
}
