﻿using System;
using System.Collections.Generic;
using System.Linq;
using eDiary.API.Services.Validation;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
using eDiary.API.Services.Tasks.Interfaces;
using eDiary.API.Util;
using Ninject;

namespace eDiary.API.Services.Tasks
{
    public class TaskService: ITaskService
    {
        private readonly IUnitOfWork uow;

        public TaskService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async System.Threading.Tasks.Task<IEnumerable<TaskCard>> GetAllTasksAsync()
        {
            var tasks = await uow.TaskRepository.GetAllAsync();
            return ConvertToTaskCards(tasks);
        }

        public async System.Threading.Tasks.Task<IEnumerable<TaskCard>> GetSectionTasksAsync(int sectionId)
        {
            Section section = await TryFindSection(sectionId);
            return ConvertToTaskCards(section.Tasks);
        }
        
        public async System.Threading.Tasks.Task<IEnumerable<TaskCard>> GetTasksByTagAsync(int tagId)
        {
            var tag = await TryFindTag(tagId);
            var tasks = new List<TaskCard>();

            foreach (var x in tag.TagReferences)
            {
                if (x.TaskId != null)
                    tasks.Add(await GetTaskAsync((int)x.TaskId));
            }

            return tasks.ToArray();
        }

        public async System.Threading.Tasks.Task<TaskCard> GetTaskAsync(int id)
        {
            return new TaskCard(await TryFindTask(id));
        }
        
        public async System.Threading.Tasks.Task CreateTaskAsync(TaskCard card)
        {
            Validate.NotNull(card, "Task card");
            var t = new Task
            {
                Header = card.Header,
                Description = card.Description,
                Status = (await uow.StatusRepository.GetByConditionAsync(x => x.Name == card.TaskStatus)).FirstOrDefault(),
                CardStatus = (await uow.CardStatusRepository.GetByConditionAsync(x => x.Name == card.CardStatus)).FirstOrDefault(),
                CreatedAt = card.CreatedAt,
                UpdatedAt = card.CreatedAt,
                Deadline = card.Deadline,
                Progress = card.Progress,
                Priority = (await uow.PriorityRepository.GetByConditionAsync(x => x.Name == card.Priority)).FirstOrDefault(),
                Difficulty = (await uow.DifficultyRepository.GetByConditionAsync(x => x.Name == card.Difficulty)).FirstOrDefault()
            };
            await uow.TaskRepository.CreateAsync(t);
        }
        
        public async System.Threading.Tasks.Task UpdateTaskAsync(TaskCard card)
        {
            Validate.NotNull(card, "Task card");
            var task = await TryFindTask(card.TaskId);

            task.Header = card.Header;
            task.Description = card.Description;
            task.Status = (await uow.StatusRepository.GetByConditionAsync(x => x.Name == card.CardStatus)).FirstOrDefault();
            task.CardStatus = (await uow.CardStatusRepository.GetByConditionAsync(x => x.Name == card.CardStatus)).FirstOrDefault();
            task.CreatedAt = card.CreatedAt;
            task.UpdatedAt = card.UpdatedAt;
            task.Deadline = card.Deadline;
            task.Progress = card.Progress;
            task.Priority = (await uow.PriorityRepository.GetByConditionAsync(x => x.Name == card.Priority)).FirstOrDefault();
            task.Difficulty = (await uow.DifficultyRepository.GetByConditionAsync(x => x.Name == card.Difficulty)).FirstOrDefault();

            uow.TaskRepository.Update(task);
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            uow.TaskRepository.Delete(await TryFindTask(id));
        }

        private async System.Threading.Tasks.Task<Section> TryFindSection(int id)
        {
            var section = (await uow.SectionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (section == null) throw new Exception("Section not found");
            return section;
        }

        private async System.Threading.Tasks.Task<Task> TryFindTask(int id)
        {
            var task = (await uow.TaskRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (task == null) throw new Exception("Task not found");
            return task;
        }
        
        private async System.Threading.Tasks.Task<Tag> TryFindTag(int id)
        {
            var tag = (await uow.TagRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (tag == null) throw new Exception("Tag not found");
            return tag;
        }

        private static IEnumerable<TaskCard> ConvertToTaskCards(IEnumerable<Task> tasks)
        {
            var cards = new List<TaskCard>();
            foreach (var t in tasks)
            {
                cards.Add(new TaskCard(t));
            }
            return cards;
        }
    }
}
