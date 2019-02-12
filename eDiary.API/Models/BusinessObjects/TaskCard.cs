using eDiary.API.Models.Entities;

namespace eDiary.API.Models.BusinessObjects
{
    public class TaskCard
    {
        public int TaskId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string TaskStatus { get; set; }
        public string CardStatus { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Deadline { get; set; }
        public int Progress { get; set; }
        public string Priority { get; set; }
        public string Difficulty { get; set; }

        public TaskCard(Task entity)
        {
            TaskId = entity.Id;
            Header = entity.Header;
            Description = entity.Description;
            TaskStatus = entity.Status.Name;
            CardStatus = entity.CardStatus.Name;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
            Deadline = entity.Deadline;
            Progress = entity.Progress.Value;
            Priority = entity.Priority.Name;
            Difficulty = entity.Difficulty.Name;
        }
    }
}
