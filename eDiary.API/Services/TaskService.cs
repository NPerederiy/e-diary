using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Interfaces;

namespace eDiary.API.Services
{
    public class TaskService: ITaskService
    {
        private readonly IUnitOfWork uow;

        public TaskService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
