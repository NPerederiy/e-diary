using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectCard>> GetAllProjectsAsync();
        Task<IEnumerable<ProjectCard>> GetProjectsByCategoryAsync(int categoryId);
        Task<ProjectCard> GetProjectCardAsync(int projectId);
        Task<ProjectPage> GetProjectPageAsync(int projectId);
        void CreateProjectAsync(ProjectCard project);
        void UpdateProjectAsync(ProjectCard project);
        void DeleteProjectAsync(int id);
    }
}
