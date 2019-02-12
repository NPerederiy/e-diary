using eDiary.API.Filters;
using eDiary.API.Services.Tasks.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace eDiary.API.Controllers
{
    [RoutePrefix("categories")]
    public class PrjCategoriesController : ApiController
    {
        private readonly ITaskService ts;

        public PrjCategoriesController(ITaskService ts)
        {
            this.ts = ts;
        }

        // GET api/categories
        [HttpGet]
        [Authenticated]
        public IEnumerable<object> GetAllCategories()
        {
            return null;
        }

        // GET api/categories/1
        [HttpGet]
        [Authenticated]
        public object GetCategoryById(int id)
        {
            return null;
        }

        // POST api/categories 
        [HttpPost]
        [Authenticated]
        public void CreateCategory([FromBody]string value)
        {
        }

        // PUT api/categories/1 
        [HttpPut]
        [Authenticated]
        public void UpdateCategory(int id, [FromBody]string value)
        {
        }

        // DELETE api/categories/1 
        [HttpDelete]
        [Authenticated]
        public void DeleteCategoryById(int id)
        {
        }
    }
}
