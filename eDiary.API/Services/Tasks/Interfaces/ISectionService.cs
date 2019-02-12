using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionCard>> GetAllSections();
        Task<IEnumerable<SectionCard>> GetSections(int projectId);
        SectionCard GetSection(int id);
        void CreateSection(SectionCard section);
        void UpdateSection(SectionCard section);
        void DeleteSection(int id);
    }
}
