using eDiary.API.Services.Interfaces;
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
        public IEnumerable<object> GetAllProjects()
        {
            return null;
        }

        // GET api/projects/1
        [HttpGet]
        public object GetProjectById(int id)
        {
            return null;
        }

        // POST api/projects 
        [HttpPost]
        public void CreateProject([FromBody]string value)
        {
        }

        // PUT api/projects/1 
        [HttpPut]
        public void UpdateProject(int id, [FromBody]string value)
        {
        }

        // DELETE api/projects/1 
        [HttpDelete]
        public void DeleteProjectById(int id)
        {
        }
    }
}
