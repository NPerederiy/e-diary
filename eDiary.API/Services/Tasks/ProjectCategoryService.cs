using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
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

            var cards = new List<ProjectCategoryCard>();
            foreach (var c in categories)
            {
                cards.Add(new ProjectCategoryCard(c));
            }
            return cards;
        }

        public async Task<ProjectCategoryCard> GetCategoryAsync(int id)
        {
            var category = (await uow.ProjectCategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");
            return new ProjectCategoryCard(category);
        }

        public async void CreateCategory(ProjectCategoryCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            var c = new ProjectCategory
            {
                Name = card.Name,
                //UserId = ???                 // TODO: Add userId
            };
            await uow.ProjectCategoryRepository.CreateAsync(c);
        }

        public async void UpdateCategory(ProjectCategoryCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var category = (await uow.ProjectCategoryRepository.GetByConditionAsync(x => x.Id == card.CategoryId)).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");

            category.Name = card.Name;

            uow.ProjectCategoryRepository.Update(category);
        }

        public async void DeleteCategory(int id)
        {
            var category = (await uow.ProjectCategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");
            uow.ProjectCategoryRepository.Delete(category);
        }
    }
}
