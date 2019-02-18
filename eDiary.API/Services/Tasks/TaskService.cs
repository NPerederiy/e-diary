using System;
using System.Collections.Generic;
using System.Linq;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Models.Entities;
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

        public async System.Threading.Tasks.Task<IEnumerable<TaskCard>> GetAllTasksAsync()
        {
            var tasks = await uow.TaskRepository.GetAllAsync();
            return ConvertToTaskCards(tasks);
        }

        public async System.Threading.Tasks.Task<IEnumerable<TaskCard>> GetSectionTasksAsync(int sectionId)
        {
            var section = (await uow.SectionRepository.GetByConditionAsync(x => x.Id == sectionId)).FirstOrDefault();
            if (section == null) throw new Exception("Section not found");
            return ConvertToTaskCards(section.Tasks);
        }

        public async System.Threading.Tasks.Task<TaskCard> GetTaskAsync(int id)
        {
            var task = (await uow.TaskRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (task == null) throw new Exception("Task not found");
            return new TaskCard(task);
        }

        public async void CreateTask(TaskCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            if (card.TaskStatus == null) throw new ArgumentNullException(nameof(card.TaskStatus));
            if (card.CardStatus == null) throw new ArgumentNullException(nameof(card.CardStatus));
            if (card.Priority == null) throw new ArgumentNullException(nameof(card.Priority));
            if (card.Difficulty == null) throw new ArgumentNullException(nameof(card.Difficulty));

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

        public async void UpdateTask(TaskCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            if (card.TaskStatus == null) throw new ArgumentNullException(nameof(card.TaskStatus));
            if (card.CardStatus == null) throw new ArgumentNullException(nameof(card.CardStatus));
            if (card.Priority == null) throw new ArgumentNullException(nameof(card.Priority));
            if (card.Difficulty == null) throw new ArgumentNullException(nameof(card.Difficulty));

            var task = (await uow.TaskRepository.GetByConditionAsync(x => x.Id == card.TaskId)).FirstOrDefault();
            if (task == null) throw new Exception("Task not found");

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

        public async void DeleteTask(int id)
        {
            var task = (await uow.TaskRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (task == null) throw new Exception("Task not found");
            uow.TaskRepository.Delete(task);
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
