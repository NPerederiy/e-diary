using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionCard>> GetAllSectionsAsync();
        Task<IEnumerable<SectionCard>> GetProjectSectionsAsync(int projectId);
        Task<SectionCard> GetSectionAsync(int id);
        Task CreateSectionAsync(SectionCard section);
        Task UpdateSectionAsync(SectionCard section);
        Task DeleteSectionAsync(int id);
    }
}
