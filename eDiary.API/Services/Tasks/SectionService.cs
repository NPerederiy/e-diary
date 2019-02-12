using System.Collections.Generic;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
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

        public Task<IEnumerable<SectionCard>> GetAllSections()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<SectionCard>> GetSections(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public SectionCard GetSection(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateSection(SectionCard section)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSection(SectionCard section)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSection(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
