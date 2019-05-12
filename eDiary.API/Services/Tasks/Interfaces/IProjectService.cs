using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectCard>> GetProjectsByProfileIdAsync(int profileId);
        Task<IEnumerable<ProjectCard>> GetProjectsByCategoryAsync(int categoryId);
        Task<ProjectCard> GetProjectCardAsync(int projectId);
        Task<ProjectPage> GetProjectPageAsync(int projectId);
        Task<int> CreateProjectAsync(string name, int? categoryId, int profileId);
        Task UpdateProjectAsync(int projectId, string name, int? categoryId);
        Task DeleteProjectAsync(int id);
    }
}
