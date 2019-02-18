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
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork uow;

        public SectionService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<SectionCard>> GetAllSectionsAsync()
        {
            var sections = await uow.SectionRepository.GetAllAsync();
            List<SectionCard> cards = ConvertToSectionCards(sections);
            return cards;
        }

        public async Task<IEnumerable<SectionCard>> GetProjectSectionsAsync(int projectId)
        {
            var project = (await uow.ProjectRepository.GetByConditionAsync(x => x.Id == projectId)).FirstOrDefault();
            if (project == null) throw new Exception("Project not found");
            return ConvertToSectionCards(project.Sections);
        }

        public async Task<SectionCard> GetSectionAsync(int id)
        {
            var section = (await uow.SectionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (section == null) throw new Exception("Section not found");
            return new SectionCard(section);
        }

        public async void CreateSection(SectionCard section)
        {
            if (section == null) throw new ArgumentNullException(nameof(section));

            var s = new Section
            {
                Name = section.Name,
                ProjectId = section.ProjectId
            };

            await uow.SectionRepository.CreateAsync(s);
        }

        public async void UpdateSection(SectionCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));

            var section = (await uow.SectionRepository.GetByConditionAsync(x => x.Id == card.SectionId)).FirstOrDefault();
            if (section == null) throw new Exception("Section not found");

            section.Name = card.Name;

            uow.SectionRepository.Update(section);
        }

        public async void DeleteSection(int id)
        {
            var section = (await uow.SectionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (section == null) throw new Exception("Section not found");
            uow.SectionRepository.Delete(section);
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
