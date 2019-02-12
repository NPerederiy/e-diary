using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectCard>> GetAllProjects();
        Task<IEnumerable<ProjectCard>> GetProjects(int categoryId);
        ProjectCard GetProjectCard(int projectId);
        ProjectPage GetProjectPage(int projectId);
        void CreateProject(ProjectCard project);
        void UpdateProject(ProjectCard project);
        void DeleteProject(int id);
        int CalcHotTaskCount();
        int CalcImportantTaskCount();
        int CalcCompletedTaskCount();
        int CalcInProgressTaskCount();
        int CalcOverdueTaskCount();
        int CalcTotalTaskCount();
    }
}
