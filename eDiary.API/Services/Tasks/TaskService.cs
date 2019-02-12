using System.Collections.Generic;
using System.Threading.Tasks;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Tasks.Interfaces;

namespace eDiary.API.Services.Tasks
{
    public class TaskService: ITaskService
    {
        private readonly IUnitOfWork uow;

        public TaskService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Task<IEnumerable<TaskCard>> GetAllTasks()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TaskCard>> GetTasks(int sectionId)
        {
            throw new System.NotImplementedException();
        }

        public TaskCard GetTask(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateTask(TaskCard task)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTask(TaskCard task)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
