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
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork uow;

        public ProjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<ProjectCard>> GetAllProjectsAsync()
        {
            return ConvertToProjectCards(await uow.ProjectRepository.GetAllAsync(););
        }

        public async Task<IEnumerable<ProjectCard>> GetProjectsByCategoryAsync(int categoryId)
        {
            ProjectCategory category = await TryFindCategory(categoryId);
            return ConvertToProjectCards(category.Projects);
        }

        public async Task<ProjectCard> GetProjectCardAsync(int projectId)
        {
            return new ProjectCard(await TryFindProject(projectId));
        }

        public async Task<ProjectPage> GetProjectPageAsync(int projectId)
        {
            return new ProjectPage(await TryFindProject(projectId));
        }

        [VerifyProjectCard]
        public async void CreateProjectAsync(ProjectCard card)
        {
            var p = new Project
            {
                Name = card.Name,
                //UserId = ???                 // TODO: Add userId
            };
            await uow.ProjectRepository.CreateAsync(p);
        }

        [VerifyProjectCard]
        public async void UpdateProjectAsync(ProjectCard card)
        {
            var project = await TryFindProject(card.ProjectId);
            project.Name = card.Name;
            uow.ProjectRepository.Update(project);
        }

        public async void DeleteProjectAsync(int id)
        {
            uow.ProjectRepository.Delete(await TryFindProject(id));
        }

        private async Task<ProjectCategory> TryFindCategory(int categoryId)
        {
            var category = (await uow.ProjectCategoryRepository.GetByConditionAsync(x => x.Id == categoryId)).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");
            return category;
        }

        private async Task<Project> TryFindProject(int id)
        {
            var project = (await uow.ProjectRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (project == null) throw new Exception("Project not found");
            return project;
        }

        private List<ProjectCard> ConvertToProjectCards(IEnumerable<Project> projects)
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
