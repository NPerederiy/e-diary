using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDiary.API.Controllers
{
    [RoutePrefix("categories")]
    [Authenticated]
    [ConsoleLogger]
    [ExceptionFilter]
    public class PrjCategoriesController : ApiController
    {
        private readonly IProjectCategoryService pcs;

        public PrjCategoriesController(IProjectCategoryService pcs)
        {
            this.pcs = pcs;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectCategoryCard>> GetAllCategories()
        {
            return await pcs.GetAllCategoriesAsync();
        }
        
        [HttpGet]
        public async Task<ProjectCategoryCard> GetCategoryById(int? id)
        {
            Validate(id);
            return await pcs.GetCategoryAsync((int)id);
        }
        
        [HttpPost]
        public async Task CreateCategory(ProjectCategoryCard category)
        {
            Validate(category);
            await pcs.CreateCategoryAsync(category);
        }
        
        [HttpPut]
        public async Task UpdateCategory(ProjectCategoryCard category)
        {
            Validate(category);
            await pcs.UpdateCategoryAsync(category);
        }
        
        [HttpDelete]
        public async Task DeleteCategoryById(int? id)
        {
            Validate(id);
            await pcs.DeleteCategoryAsync((int)id);
        }
    }
}
