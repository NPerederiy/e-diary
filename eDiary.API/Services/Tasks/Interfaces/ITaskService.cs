﻿using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskCard>> GetAllTasksAsync();
        Task<IEnumerable<TaskCard>> GetSectionTasksAsync(int sectionId);
        Task<IEnumerable<TaskCard>> GetTasksByTagAsync(int tagId);
        Task<TaskCard> GetTaskAsync(int taskId);
        void CreateTaskAsync(TaskCard task);
        void UpdateTaskAsync(TaskCard task);
        void DeleteTaskAsync(int taskId);
    }
}
