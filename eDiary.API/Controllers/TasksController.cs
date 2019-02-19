using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Tasks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace eDiary.API.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService ts;

        public TasksController(ITaskService ts)
        {
            this.ts = ts;
        }

        // GET api/categories
        [HttpGet]
        [Authenticated]
        public async Task<IEnumerable<TaskCard>> GetAllTasks()
        {
            return await ts.GetAllTasksAsync();
        }

        // GET api/categories/1
        [HttpGet]
        [Authenticated]
        public async Task<TaskCard> GetTaskById(int id)
        {
            return await ts.GetTaskAsync(id);
        }

        // POST api/categories 
        [HttpPost]
        [Authenticated]
        public void CreateTask(TaskCard task)
        {
            ts.CreateTaskAsync(task);
        }

        // PUT api/categories/1 
        [HttpPut]
        [Authenticated]
        public void UpdateTask(TaskCard task)
        {
            ts.UpdateTaskAsync(task);
        }

        // DELETE api/categories/1 
        [HttpDelete]
        [Authenticated]
        public void DeleteTaskById(int id)
        {
            ts.DeleteTaskAsync(id);
        }
    }
}
