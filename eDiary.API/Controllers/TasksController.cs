using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace eDiary.API.Controllers
{
    [Authenticated]
    [ConsoleLogger]
    [ExceptionFilter]
    public class TasksController : ApiController
    {
        private readonly ITaskService ts;

        public TasksController()
        {
            ts = NinjectKernel.Kernel.Get<ITaskService>();
        }
        
        [HttpGet]
        public async Task<IEnumerable<TaskCard>> GetAllTasksAsync()
        {
            return await ts.GetAllTasksAsync();
        }
        
        [HttpGet]
        public async Task<TaskCard> GetTaskByIdAsync(int? id)
        {
            Validate(id);
            return await ts.GetTaskAsync((int)id);
        }
        
        [HttpGet]
        public async Task<IEnumerable<TaskCard>> GetTasksByTagAsync(int? tag)
        {
            Validate(tag);
            return await ts.GetTasksByTagAsync((int)tag);
        }
        
        [HttpPost]
        public async Task CreateTaskAsync(TaskCard task)
        {
            Validate(task);
            await ts.CreateTaskAsync(task);
        }
        
        [HttpPut]
        public async Task UpdateTaskAsync(TaskCard task)
        {
            Validate(task);
            await ts.UpdateTaskAsync(task);
        }
        
        [HttpDelete]
        public async Task DeleteTaskByIdAsync(int? id)
        {
            Validate(id);
            await ts.DeleteTaskAsync((int)id);
        }
    }
}
