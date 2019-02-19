using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using eDiary.API.Services.Tasks.Filters;
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

        public async Task<IEnumerable<ProjectCategoryCard>> GetAllCategoriesAsync()
        {
            var categories = await uow.ProjectCategoryRepository.GetAllAsync();
            return ConvertToCategoryCards(categories);
        }

        public async Task<ProjectCategoryCard> GetCategoryAsync(int id)
        {
            return new ProjectCategoryCard(await TryFindCategory(id));
        }

        [VerifyCategoryCard]
        public async void CreateCategoryAsync(ProjectCategoryCard card)
        {
            var c = new ProjectCategory
            {
                Name = card.Name,
                //UserId = ???                 // TODO: Add userId
            };
            await uow.ProjectCategoryRepository.CreateAsync(c);
        }

        [VerifyCategoryCard]
        public async void UpdateCategoryAsync(ProjectCategoryCard card)
        {
            var category = await TryFindCategory(card.CategoryId);
            category.Name = card.Name;
            uow.ProjectCategoryRepository.Update(category);
        }

        public async void DeleteCategoryAsync(int id)
        {
            uow.ProjectCategoryRepository.Delete(await TryFindCategory(id));
        }

        private async Task<ProjectCategory> TryFindCategory(int id)
        {
            var category = (await uow.ProjectCategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");
            return category;
        }

        private static List<ProjectCategoryCard> ConvertToCategoryCards(IEnumerable<ProjectCategory> categories)
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
