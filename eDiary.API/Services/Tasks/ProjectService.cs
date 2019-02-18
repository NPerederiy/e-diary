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
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork uow;

        public ProjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<ProjectCard>> GetAllProjectsAsync()
        {
            var projects = await uow.ProjectRepository.GetAllAsync();
            return ConvertToProjectCards(projects);
        }

        public async Task<IEnumerable<ProjectCard>> GetProjectsByCategoryAsync(int categoryId)
        {
            var category = (await uow.ProjectCategoryRepository.GetByConditionAsync(x => x.Id == categoryId)).FirstOrDefault();
            if (category == null) throw new Exception("Category not found");
            return ConvertToProjectCards(category.Projects);
        }

        public async Task<ProjectCard> GetProjectCardAsync(int projectId)
        {
            var project = (await uow.ProjectRepository.GetByConditionAsync(x => x.Id == projectId)).FirstOrDefault();
            if (project == null) throw new Exception("Project not found");
            return new ProjectCard(project);
        }

        public async Task<ProjectPage> GetProjectPageAsync(int projectId)
        {
            var project = (await uow.ProjectRepository.GetByConditionAsync(x => x.Id == projectId)).FirstOrDefault();
            if (project == null) throw new Exception("Project not found");
            return new ProjectPage(projectId, uow);
        }

        public async void CreateProject(ProjectCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var p = new Project
            {
                Name = card.Name,
                //UserId = ???                 // TODO: Add userId
            };

            await uow.ProjectRepository.CreateAsync(p);
        }

        public async void UpdateProject(ProjectCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var project = (await uow.ProjectRepository.GetByConditionAsync(x => x.Id == card.ProjectId)).FirstOrDefault();
            if (project == null) throw new Exception("Project not found");

            project.Name = card.Name;

            uow.ProjectRepository.Update(project);
        }

        public async void DeleteProject(int id)
        {
            var project = (await uow.ProjectRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (project == null) throw new Exception("Project not found");
            uow.ProjectRepository.Delete(project);
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
