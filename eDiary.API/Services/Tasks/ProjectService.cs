using System.Collections.Generic;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Tasks.Interfaces;

namespace eDiary.API.Services.Tasks
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork uow;

        public ProjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Task<IEnumerable<ProjectCard>> GetAllProjectsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ProjectCard>> GetProjectsByCategoryAsync(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjectCard> GetProjectCardAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProjectPage> GetProjectPageAsync(int projectId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateProject(ProjectCard project)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProject(ProjectCard project)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProject(int id)
        {
            throw new System.NotImplementedException();
        }

        public int CalcCompletedTaskCount()
        {
            throw new System.NotImplementedException();
        }

        public int CalcHotTaskCount()
        {
            throw new System.NotImplementedException();
        }

        public int CalcImportantTaskCount()
        {
            throw new System.NotImplementedException();
        }

        public int CalcInProgressTaskCount()
        {
            throw new System.NotImplementedException();
        }

        public int CalcOverdueTaskCount()
        {
            throw new System.NotImplementedException();
        }

        public int CalcTotalTaskCount()
        {
            throw new System.NotImplementedException();
        }
    }
}
