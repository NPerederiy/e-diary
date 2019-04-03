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
    public class ProjectService : BaseService, IProjectService
    {
        private readonly IUnitOfWork uow;

        public ProjectService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<IEnumerable<ProjectCard>> GetAllProjectsAsync()
        {
            return ConvertToProjectCards(await uow.ProjectRepository.GetAllAsync());
        }

        public async Task<IEnumerable<ProjectCard>> GetProjectsByCategoryAsync(int categoryId)
        {
            Entities.ProjectCategory category = await FindCategoryAsync(x => x.Id == categoryId);
            return ConvertToProjectCards(category.Projects);
        }

        public async Task<ProjectCard> GetProjectCardAsync(int projectId)
        {
            return new ProjectCard(await FindProjectAsync(x => x.Id == projectId));
        }

        public async Task<ProjectPage> GetProjectPageAsync(int projectId)
        {
            return new ProjectPage(await FindProjectAsync(x => x.Id == projectId));
        }
        
        public async Task CreateProjectAsync(ProjectCard card)
        {
            Validate.NotNull(card, "Project card");
            var p = new Entities.Project
            {
                Name = card.Name,
                //UserId = ???                 // TODO: Add userId
            };
            await uow.ProjectRepository.CreateAsync(p);
        }
        
        public async Task UpdateProjectAsync(ProjectCard card)
        {
            Validate.NotNull(card, "Project card");
            var project = await FindProjectAsync(x => x.Id == card.ProjectId);
            project.Name = card.Name;
            uow.ProjectRepository.Update(project);
        }

        public async Task DeleteProjectAsync(int id)
        {
            uow.ProjectRepository.Delete(await FindProjectAsync(x => x.Id == id));
        }

        private async Task<Entities.ProjectCategory> TryFindCategoryAsync(Expression<Func<Entities.ProjectCategory, bool>> condition)
        {
            return await FindEntityAsync(uow.ProjectCategoryRepository, condition);
        }

        private async Task<Entities.ProjectCategory> FindCategoryAsync(Expression<Func<Entities.ProjectCategory, bool>> condition)
        {
            return await FindEntityAsync(uow.ProjectCategoryRepository, condition);
        }

        private async Task<Entities.Project> FindProjectAsync(Expression<Func<Entities.Project, bool>> condition)
        {
            return await FindEntityAsync(uow.ProjectRepository, condition);
        }

        private List<ProjectCard> ConvertToProjectCards(IEnumerable<Entities.Project> projects)
        {
            var cards = new List<ProjectCard>();
            foreach (var p in projects)
            {
                cards.Add(new ProjectCard(p));
            }
            return cards;
        }
    }
}
