using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;

namespace eDiary.API.Services.Tasks
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork uow;

        public SectionService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<IEnumerable<SectionCard>> GetAllSectionsAsync()
        {
            var sections = await uow.SectionRepository.GetAllAsync();
            return ConvertToSectionCards(sections);
        }

        public async Task<IEnumerable<SectionCard>> GetProjectSectionsAsync(int projectId)
        {
            Project project = await TryFindProject(projectId);
            return ConvertToSectionCards(project.Sections);
        }

        public async Task<SectionCard> GetSectionAsync(int id)
        {
            return new SectionCard(await TryFindSection(id));
        }
        
        public async System.Threading.Tasks.Task CreateSectionAsync(SectionCard card)
        {
            Validate.NotNull(card, "Section card");
            var s = new Section
            {
                Name = card.Name,
                ProjectId = card.ProjectId
            };
            await uow.SectionRepository.CreateAsync(s);
        }
        
        public async System.Threading.Tasks.Task UpdateSectionAsync(SectionCard card)
        {
            Validate.NotNull(card, "Section card");
            var section = await TryFindSection(card.SectionId);
            section.Name = card.Name;
            uow.SectionRepository.Update(section);
        }

        public async System.Threading.Tasks.Task DeleteSectionAsync(int id)
        {
            uow.SectionRepository.Delete(await TryFindSection(id));
        }

        private async Task<Project> TryFindProject(int id)
        {
            var project = (await uow.ProjectRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (project == null) throw new Exception("Project not found");
            return project;
        }

        private async Task<Section> TryFindSection(int id)
        {
            var section = (await uow.SectionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (section == null) throw new Exception("Section not found");
            return section;
        }

        private static List<SectionCard> ConvertToSectionCards(IEnumerable<Section> sections)
        {
            var cards = new List<SectionCard>();
            foreach (var s in sections)
            {
                cards.Add(new SectionCard(s));
            }
            return cards;
        }
    }
}
