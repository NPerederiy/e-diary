using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [JwtAuthentication]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
        public async Task<int> CreateTaskAsync(CreateTaskData task)
        {
            Services.Validation.Validate.NotNull(task);
            Services.Validation.Validate.NotNull(task.Header, "Task header");
            Services.Validation.Validate.NotNull(task.SectionId, "Section id");
            return await ts.CreateTaskAsync(task.Header, task.SectionId);
        }
        
        [HttpPut]
        public async Task UpdateTaskAsync(UpdateTaskData task)
        {
            Services.Validation.Validate.NotNull(task);
            Services.Validation.Validate.NotNull(task.TaskId, "Task id");
            Services.Validation.Validate.NotNull(task.Header, "Task header");
            Services.Validation.Validate.NotNull(task.TaskStatus, "Task status");
            Services.Validation.Validate.NotNull(task.CardStatus, "Task card status");
            await ts.UpdateTaskAsync(task);
        }

        //[HttpPut]
        //public async Task UpdateTaskAsync(UpdateTaskData task)
        //{
        //    Services.Validation.Validate.NotNull(task);
        //    Services.Validation.Validate.NotNull(task.Id, "Task id");
        //    Services.Validation.Validate.NotNull(task.Header, "Task header");
        //    Services.Validation.Validate.NotNull(task.TaskStatus, "Task status");
        //    Services.Validation.Validate.NotNull(task.CardStatus, "Task card status");
        //    await ts.UpdateTaskAsync(task);
        //}

        [HttpDelete]
        public async Task DeleteTaskByIdAsync(int? id)
        {
            Services.Validation.Validate.NotNull(id);
            await ts.DeleteTaskAsync((int)id);
        }
    }
}
