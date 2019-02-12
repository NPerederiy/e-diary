using System.Collections.Generic;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Tasks.Interfaces;

namespace eDiary.API.Services.Tasks
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private readonly IUnitOfWork uow;

        public ProjectCategoryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Task<IEnumerable<ProjectCategoryCard>> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public ProjectCategoryCard GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateCategory(ProjectCategoryCard category)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCategory(ProjectCategoryCard category)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
