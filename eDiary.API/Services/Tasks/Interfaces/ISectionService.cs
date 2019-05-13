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
        Task<int> CreateSectionAsync(string name, int projectId);
        Task UpdateSectionAsync(int sectionId, string name, int projectId);
        Task DeleteSectionAsync(int id);
    }
}
