using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eDiary.API.Controllers
{
    [RoutePrefix("categories")]
    public class PrjCategoriesController : Controller
    {
        private readonly IProjectCategoryService pcs;

        public PrjCategoriesController(IProjectCategoryService pcs)
        {
            this.pcs = pcs;
        }

        // GET api/categories
        [HttpGet]
        [Authenticated]
        public async Task<IEnumerable<ProjectCategoryCard>> GetAllCategories()
        {
            return await pcs.GetAllCategoriesAsync();
        }

        // GET api/categories/1
        [HttpGet]
        [Authenticated]
        public async Task<ProjectCategoryCard> GetCategoryById(int id)
        {
            return await pcs.GetCategoryAsync(id);
        }

        // POST api/categories 
        [HttpPost]
        [Authenticated]
        public void CreateCategory(ProjectCategoryCard category)
        {
            pcs.CreateCategory(category);
        }

        // PUT api/categories/1 
        [HttpPut]
        [Authenticated]
        public void UpdateCategory(ProjectCategoryCard category)
        {
            pcs.UpdateCategory(category);
        }

        // DELETE api/categories/1 
        [HttpDelete]
        [Authenticated]
        public void DeleteCategoryById(int id)
        {
            pcs.DeleteCategory(id);
        }
    }
}
