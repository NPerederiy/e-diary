using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskCard>> GetAllTasks();
        Task<IEnumerable<TaskCard>> GetTasks(int sectionId);
        TaskCard GetTask(int id);
        void CreateTask(TaskCard task);
        void UpdateTask(TaskCard task);
        void DeleteTask(int id);
    }
}
