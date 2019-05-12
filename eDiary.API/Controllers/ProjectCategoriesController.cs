using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class ProjectCategoriesController : ApiController
    {
        private readonly IProjectCategoryService pcs;
        private readonly IIdentityService iis;

        public ProjectCategoriesController()
        {
            pcs = NinjectKernel.Kernel.Get<IProjectCategoryService>();
            iis = NinjectKernel.Kernel.Get<IIdentityService>();
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProjectCategoryCard>> GetAllCategories()
        {
            return await pcs.GetCategoriesByProfileIdAsync(iis.GetProfileIdFromTokenPayload(GetTokenFromHeader()));
        }
        
        [HttpGet]
        public async Task<ProjectCategoryCard> GetCategoryById(int? id)
        {
            Services.Validation.Validate.NotNull(id, "Category id");
            return await pcs.GetCategoryAsync((int)id);
        }

        [HttpPost]
        public async Task<int> CreateCategory([FromBody] string name)
        {
            //Services.Validation.Validate.NotNull(name, "Category name");
            var profileId = iis.GetProfileIdFromTokenPayload(GetTokenFromHeader());
            var categoryId = await pcs.CreateCategoryAsync(name, profileId);

            return categoryId;
        }

        [HttpPut]
        public async Task UpdateCategory(UpdateCategoryData category)
        {
            Services.Validation.Validate.NotNull(category);
            Services.Validation.Validate.NotNull(category.Id, "Category id");
            Services.Validation.Validate.NotNull(category.Name, "Category name");
            await pcs.UpdateCategoryAsync(category.Id, category.Name);
        }
        
        [HttpDelete]
        public async Task DeleteCategoryById(int? id)
        {
            Services.Validation.Validate.NotNull(id, "Category id");
            await pcs.DeleteCategoryAsync((int)id);
        }

        private string GetTokenFromHeader()
        {
            return Request.Headers.GetValues("Authorization").First().Split(' ')[1];
        }
    }
}
