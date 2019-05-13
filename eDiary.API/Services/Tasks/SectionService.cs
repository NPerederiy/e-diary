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
    public class SectionService : BaseService, ISectionService
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
            Entities.Project project = await FindEntityAsync(uow.ProjectRepository, x => x.Id == projectId);
            return ConvertToSectionCards(project.Sections);
        }

        public async Task<SectionCard> GetSectionAsync(int id)
        {
            return new SectionCard(await FindSectionAsync(x => x.Id == id));
        }
        
        public async Task<int> CreateSectionAsync(string name, int projectId)
        {
            var s = new Entities.Section
            {
                Name = name,
                ProjectId = projectId
            };
            await uow.SectionRepository.CreateAsync(s);
            return s.Id;
        }
        
        public async Task UpdateSectionAsync(int sectionId, string name, int projectId)
        {
            var section = await FindSectionAsync(x => x.Id == sectionId);
            section.Name = name;
            uow.SectionRepository.Update(section);
        }

        public async Task DeleteSectionAsync(int id)
        {
            uow.SectionRepository.Delete(await FindSectionAsync(x => x.Id == id));
        }

        private async Task<Entities.Section> FindSectionAsync(Expression<Func<Entities.Section, bool>> condition)
        {
            return await FindEntityAsync(uow.SectionRepository, condition);
        }

        private static List<SectionCard> ConvertToSectionCards(IEnumerable<Entities.Section> sections)
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
