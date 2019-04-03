using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities = eDiary.API.Models.Entities;

namespace eDiary.API.Services.Tasks
{
    public class ProjectCategoryService : BaseService, IProjectCategoryService
    {
        private readonly IUnitOfWork uow;

        public ProjectCategoryService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<IEnumerable<ProjectCategoryCard>> GetAllCategoriesAsync()
        {
            var categories = await uow.ProjectCategoryRepository.GetAllAsync();
            return ConvertToCategoryCards(categories);
        }

        public async Task<ProjectCategoryCard> GetCategoryAsync(int id)
        {
            return new ProjectCategoryCard(await FindCategoryAsync(x => x.Id == id));
        }
        
        public async Task CreateCategoryAsync(ProjectCategoryCard card)
        {
            Validate.NotNull(card, "Project category card");
            var c = new Entities.ProjectCategory
            {
                Name = card.Name,
                //UserId = ???                 // TODO: Add userId
            };
            await uow.ProjectCategoryRepository.CreateAsync(c);
        }
        
        public async Task UpdateCategoryAsync(ProjectCategoryCard card)
        {
            Validate.NotNull(card, "Project category card");
            var category = await FindCategoryAsync(x => x.Id == card.CategoryId);
            category.Name = card.Name;
            uow.ProjectCategoryRepository.Update(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            uow.ProjectCategoryRepository.Delete(await FindCategoryAsync(x => x.Id == id));
        }

        private async Task<Entities.ProjectCategory> FindCategoryAsync(Expression<Func<Entities.ProjectCategory, bool>> condition)
        {
            return await FindEntityAsync(uow.ProjectCategoryRepository, condition);
        }

        private static List<ProjectCategoryCard> ConvertToCategoryCards(IEnumerable<Entities.ProjectCategory> categories)
        {
            var cards = new List<ProjectCategoryCard>();
            foreach (var c in categories)
            {
                cards.Add(new ProjectCategoryCard(c));
            }
            return cards;
        }
    }
}
