using eDiary.API.Models.Entities;
using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class TaskCard
    {
        [JsonProperty("taskId")]
        public int TaskId { get; set; }
        [JsonProperty("header")]
        public string Header { get; set; }
        [JsonProperty("descr")]
        public string Description { get; set; }
        [JsonProperty("taskStatus")]
        public string TaskStatus { get; set; }
        [JsonProperty("cardStatus")]
        public string CardStatus { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
        [JsonProperty("deadline")]
        public string Deadline { get; set; }
        [JsonProperty("progress")]
        public int Progress { get; set; }
        [JsonProperty("priority")]
        public string Priority { get; set; }
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty("comments")]
        public CommentBO[] Comments { get; set; }
        [JsonProperty("files")]
        public FileBO[] Files { get; set; }
        [JsonProperty("links")]
        public LinkBO[] Links { get; set; }
        [JsonProperty("subtasks")]
        public SubtaskBO[] Subtasks { get; set; }
        [JsonProperty("tags")]
        public TagBO[] Tags { get; set; }

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
