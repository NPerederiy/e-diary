using eDiary.API.Filters;
using eDiary.API.Services.Tasks.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace eDiary.API.Controllers
{
    [RoutePrefix("projects")]
    public class ProjectsController : ApiController
    {
        private readonly ITaskService ts;

        public ProjectsController(ITaskService ts)
        {
            this.ts = ts;
        }

        // GET api/projects
        [HttpGet]
        [Authenticated]
        public IEnumerable<object> GetAllProjects()
        {
            return null;
        }

        // GET api/projects/1
        [HttpGet]
        [Authenticated]
        public object GetProjectById(int id)
        {
            return null;
        }

        // POST api/projects 
        [HttpPost]
        [Authenticated]
        public void CreateProject([FromBody]string value)
        {
        }

        // PUT api/projects/1 
        [HttpPut]
        [Authenticated]
        public void UpdateProject(int id, [FromBody]string value)
        {
        }

        // DELETE api/projects/1 
        [HttpDelete]
        [Authenticated]
        public void DeleteProjectById(int id)
        {
        }
    }
}
