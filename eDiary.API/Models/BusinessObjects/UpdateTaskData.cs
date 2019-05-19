using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class UpdateTaskData {
        [JsonProperty("taskId")]
        public int? TaskId { get; set; }

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

        public UpdateTaskData(
            int? id, 
            string header, 
            string descr, 
            string taskStatus, 
            string cardStatus,
            string createdAt,
            string updatedAt,
            string deadline,
            int progress,
            string priority,
            string difficulty
            )
        {
            TaskId = id;
            Header = header;
            Description = descr;
            TaskStatus = taskStatus;
            CardStatus = cardStatus;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Deadline = deadline;
            Progress = progress;
            Priority = priority;
            Difficulty = difficulty;
        }
    }
}
